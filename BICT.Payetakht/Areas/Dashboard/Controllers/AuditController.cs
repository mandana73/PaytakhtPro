using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;
using BICT.Payetakht.Helper;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class AuditController : Controller
    {
        private AuditRepository auditRepository;
        private CarManufactureRepository carManufactureRepository;
        private CarModelRepository carModelRepository;
        private CarYearRepository carYearRepository;
        private CarDetailRepository carDetailRepository;

        public AuditController()
        {
            auditRepository = new AuditRepository();
            carManufactureRepository = new CarManufactureRepository();
            carModelRepository = new CarModelRepository();
            carYearRepository = new CarYearRepository();
            carDetailRepository = new CarDetailRepository();
        }

        public ActionResult Detail(int id)
        {
            var audit = auditRepository.Getitem(id);
            audit.RequestDatePersian = new PersianDateTime(audit.RequestDate).ToString(PersianDateTimeFormat.Date);
            audit.PaymentDatePersian = audit.PaymentDate != null ? new PersianDateTime(audit.PaymentDate.Value).ToString(PersianDateTimeFormat.FullDateFullTime) : string.Empty;
            return View(audit);
        }

        public ActionResult Index(int p = 1, int? read = null, int? done = null)
        {
            ViewBag.Page = p;
            ViewBag.Read = read;
            ViewBag.Done = done;
            var audits = auditRepository.GetPagedList(p, read, done);
            foreach (var item in audits)
            {
                item.HaveInspection = auditRepository.HaveInspection(item.ID);
                var path = Server.MapPath("~/Content/Audit/" + item.ID);
                if (Directory.Exists(path) && Directory.GetFiles(path).Length > 0)
                {
                    item.HavePicture = true;
                }
            }
            return View(audits);
        }

        [HttpGet]
        public ActionResult Inspection(int id)
        {
            var inspection = auditRepository.GetInspection(id);
            ViewBag.BodyList = new List<SelectListItem>
            {
                new SelectListItem { Text = "انتخاب نمایید", Value = ""},
                new SelectListItem { Text = "سالم", Value="سالم"},
                new SelectListItem { Text = "صافکاری بدون رنگ", Value = "صافکاری بدون رنگ" },
                new SelectListItem { Text = "صافکاری با رنگ", Value = "صافکاری با رنگ" },
                new SelectListItem { Text = "ضربه خوردگی جزئی", Value = "ضربه خوردگی جزئی" },
                new SelectListItem { Text = "تعویض شده", Value = "تعویض شده" },
            };
            return View(inspection);
        }

        [HttpPost]
        public ActionResult Inspection(int id, InspectionViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            var path = Server.MapPath("~/Content/Audit/" + id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            int index = 1;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        if (!Util.CheckFormat(file.FileName, "png", "jpg", "jpeg"))
                        {
                            continue;
                        }
                        var ext = Path.GetExtension(file.FileName);
                        var filePath = path + "/" + index + ext;
                        while (System.IO.File.Exists(filePath))
                        {
                            index++;
                            filePath = path + "/" + index + ext;
                        }
                        file.SaveAs(filePath);
                        index++;
                    }
                }
            }
            auditRepository.InsertInspection(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Picture(int id)
        {
            ViewBag.ID = id;
            var path = Server.MapPath("~/Content/Audit/" + id);
            var list = Directory.GetFiles(path).Select(x => Path.GetFileName(x));
            return View(list);
        }

        [HttpGet]
        public ActionResult PictureDelete(int id, string name)
        {
            var path = Server.MapPath("~/Content/Audit/" + id + "/" + name);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Picture", new { id });
        }

        [HttpGet]
        public ActionResult DeleteInspection(int ID)
        {
            auditRepository.DeleteInspection(ID);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult CreateInspection()
        {
            var mlist = carManufactureRepository.GetList()
                 .Select(x => new SelectListItem
                 {
                     Text = x.Title,
                     Value = x.ID.ToString()
                 }).ToList();
            mlist.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.CarManufacturerList = mlist;
            ViewBag.BodyList = new List<SelectListItem>
            {
                new SelectListItem { Text = "انتخاب نمایید", Value = ""},
                new SelectListItem { Text = "سالم", Value="سالم"},
                new SelectListItem { Text = "صافکاری بدون رنگ", Value = "صافکاری بدون رنگ" },
                new SelectListItem { Text = "صافکاری با رنگ", Value = "صافکاری با رنگ" },
                new SelectListItem { Text = "ضربه خوردگی جزئی", Value = "ضربه خوردگی جزئی" },
                new SelectListItem { Text = "تعویض شده", Value = "تعویض شده" },
            };
            return View(new CreateInspectionViewModel());
        }
        [HttpPost]
        public ActionResult CreateInspection(CreateInspectionViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            var avm = new AuditViewModel()
            {
                CarManufactureID = model.CarManufactureID,
                CarDetailID = model.CarDetailID,
                CarModelID = model.CarModelID,
                CarYearID = model.CarYearID,
                RequestDatePersian = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date),
                Email = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty,
                IsDone = true,
                IsRead = true,
                Phone = string.Empty,
                Price = 0,
            };
            var id = auditRepository.Create(avm);
            var path = Server.MapPath("~/Content/Audit/" + id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            int index = 1;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        if (!Util.CheckFormat(file.FileName, "png", "jpg", "jpeg"))
                        {
                            continue;
                        }
                        var ext = Path.GetExtension(file.FileName);
                        var filePath = path + "/" + index + ext;
                        while (System.IO.File.Exists(filePath))
                        {
                            index++;
                            filePath = path + "/" + index + ext;
                        }
                        file.SaveAs(filePath);
                        index++;
                    }
                }
            }
            var mm = new InspectionViewModel()
            {
                Description = model.Description,
                Color = model.Color,
                ColorType = model.ColorType,
                GearBoxNumner = model.GearBoxNumner,
                GearBoxType = model.GearBoxType,
                BodyType = model.BodyType,
                Usage = model.Usage,
                EngineVolume = model.EngineVolume,
                CylinderNumber = model.CylinderNumber,
                FuelType = model.FuelType,
                Roof = model.Roof,
                Trunk = model.Trunk,
                Hood = model.Hood,
                DoorRightFront = model.DoorRightFront,
                DoorLeftFront = model.DoorLeftFront,
                DoorRightRear = model.DoorRightRear,
                DoorLeftRear = model.DoorLeftRear,
                PillarRightFront = model.PillarRightFront,
                PillarLeftFront = model.PillarLeftFront,
                PillarRightRear = model.PillarRightRear,
                PillarLeftRear = model.PillarLeftRear,
                FenderRightFront = model.FenderRightFront,
                FenderLeftFront = model.FenderLeftFront,
                FenderRightRear = model.FenderRightRear,
                FenderLeftRear = model.FenderLeftRear,
                PedalRight = model.PedalRight,
                PedalLeft = model.PedalLeft,
                ChassisFront = model.ChassisFront,
                ChassisRear = model.ChassisRear,
                TireRightFront = model.TireRightFront,
                TireLeftFront = model.TireLeftFront,
                TireRightRear = model.TireRightRear,
                TireLeftRear = model.TireLeftRear,
                TireSpare = model.TireSpare,
            };
            auditRepository.InsertInspection(id, mm);
            return RedirectToAction("Index");
        }

        public JsonResult GetCarModel(int carManufactureID)
        {
            var list = carModelRepository.GetList(carManufactureID).Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.ID.ToString()
            }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarYear(int carModelID)
        {
            var list = carYearRepository.GetList(carModelID).Select(x => new SelectListItem
            {
                Text = x.Year.ToString(),
                Value = x.ID.ToString()
            }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarDetail(int carModelID)
        {
            var list = carDetailRepository.GetList(carModelID)
                .Select(x => new SelectListItem
                {
                    Text = x.Title.ToString(),
                    Value = x.ID.ToString()
                }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
