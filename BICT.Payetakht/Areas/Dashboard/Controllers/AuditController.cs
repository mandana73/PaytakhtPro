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

        public AuditController()
        {
            auditRepository = new AuditRepository();
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

    }
}
