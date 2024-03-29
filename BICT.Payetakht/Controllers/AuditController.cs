﻿namespace BICT.Payetakht.Controllers
{
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;
    using BICT.Payetakht.Data.Repository;
    using BICT.Payetakht.Data.ViewModels;
    using BICT.Payetakht.Helper;
    using BICT.Payetakht.Payment;

    public class AuditController : Controller
    {
        private CarManufactureRepository carManufactureRepository;
        private CityRepository cityRepository;
        private CarModelRepository carModelRepository;
        private CarYearRepository carYearRepository;
        private CarDetailRepository carDetailRepository;
        private CarModelYearDetailRepository carModelYearDetailRepository;
        private AuditRepository auditRepository;
        private AuditTempRepository auditTempRepository;

        public AuditController()
        {
            carManufactureRepository = new CarManufactureRepository();
            cityRepository = new CityRepository();
            carModelRepository = new CarModelRepository();
            carYearRepository = new CarYearRepository();
            carDetailRepository = new CarDetailRepository();
            carModelYearDetailRepository = new CarModelYearDetailRepository();
            auditRepository = new AuditRepository();
            auditTempRepository = new AuditTempRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var mlist = carManufactureRepository.GetList()
                 .Select(x => new SelectListItem
                 {
                     Text = x.Title,
                     Value = x.ID.ToString()
                 }).OrderBy(x=>x.Text).ToList();
            mlist.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.CarManufacturerList = mlist;

            var list = cityRepository.GetList()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Title,
                                Value = x.ID.ToString()
                            }).OrderBy(x => x.Text).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.CityList = list;
            if (TempData["SuccessAudit"] != null && TempData["SuccessAudit"].ToString() == "Success")
            {
                ViewBag.ShowSuccessMessage = true;
            }
            if (TempData["FailAudit"] != null && TempData["FailAudit"].ToString() != "")
            {
                ViewBag.FailMessage = TempData["FailAudit"].ToString();
            }
            if (TempData["RefId"] != null && TempData["OrdeID"] != null && TempData["authority"] != null)
            {
                ViewBag.ReturnBank = true;
                ViewBag.ReferID = TempData["RefId"];
                ViewBag.OrderID = TempData["OrdeID"];
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(AuditViewModel audit)
        {
            var id = auditTempRepository.Create(audit);
            var mlist = carManufactureRepository.GetList()
                 .Select(x => new SelectListItem
                 {
                     Text = x.Title,
                     Value = x.ID.ToString()
                 }).ToList();
            mlist.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.CarManufacturerList = mlist;

            var list = cityRepository.GetList()
                            .Select(x => new SelectListItem
                            {
                                Text = x.Title,
                                Value = x.ID.ToString()
                            }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.CityList = list;
            return RedirectToAction("Detail", new { id });
        }

        public ActionResult Detail(int id)
        {
            var a = auditTempRepository.GetItem(id);
            return View(a);
        }

        public ActionResult Finalize(int id)
        {
            var a = auditTempRepository.GetItem(id);
            a.RequestDatePersian = new PersianDateTime(a.RequestDate).ToString(PersianDateTimeFormat.Date);
            a.PaymentTypeID = 1;
            auditRepository.Create(a);
            TempData["SuccessAudit"] = "Success";
            return RedirectToAction("Index");
        }

        public ActionResult ZarinPalPayment(int ID)
        {
            var requestitem = auditTempRepository.GetItem(ID);
            string MerchantID = "e53f3f7c-d9f1-11e8-a28f-000c295eb8fc";
            string authority;
            var urlWebConfig = ConfigurationManager.AppSettings["ZarinPalPayment"];
            string CallbackURL = "http://" + Request.Url.Authority + urlWebConfig + "/" + requestitem.ID;
            var FinalPrice = requestitem.Price - (requestitem.Price / 10);
            int status = ZarinPal.ZarinpalPayment(MerchantID, FinalPrice, " کارشناسی برای " + requestitem.CarModelTitle + " " + requestitem.CarManufactureTitle, requestitem.Email, requestitem.Phone, CallbackURL, out authority);
            if (status == 100)
            {
                ////For release mode
                Response.Redirect("https://zarinpal.com/pg/StartPay/" + authority);
                ////For test mode
                //Response.Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + authority);
                return null;
            }
            TempData["authority"] = authority;
            TempData["Message"] = ZarinPal.GetMessage(status);
            return View("Detail", requestitem);
        }

        public ActionResult ZarinpalPaymentVerification(int id, string authority, string Status)
        {
            if (!string.IsNullOrEmpty(Status) && !string.IsNullOrEmpty(authority))
            {
                if (Status.Equals("OK"))
                {
                    var requestitem = auditTempRepository.GetItem(id);
                    long refID;
                    string MerchantID = "e53f3f7c-d9f1-11e8-a28f-000c295eb8fc";
                    var FinalPrice = requestitem.Price - (requestitem.Price / 10);
                    int statuses = ZarinPal.ZarinpalPaymentVerification(MerchantID, authority, FinalPrice, out refID);
                    if (statuses == 100 || statuses == 101)
                    {

                        ViewBag.RefId = "کد پیگیری: " + refID + " - کد سفارش: " + id;
                        auditTempRepository.Edit(id, refID, authority, 2,FinalPrice);
                        TempData["RefId"] = refID;
                        TempData["OrdeID"] = id;
                        TempData["authority"] = authority;
                        var audit = auditTempRepository.GetItem(id);
                        audit.RequestDatePersian = new PersianDateTime(audit.RequestDate).ToString(PersianDateTimeFormat.Date);
                        auditRepository.Create(audit);
                        TempData["SuccessAudit"] = "Success";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["FailAudit"] = ZarinPal.GetMessage(statuses);
                    }
                }
                else
                {
                    TempData["FailAudit"] = "کد مرجع: " + Request.QueryString["Authority"] + " - وضعیت:" + Request.QueryString["Status"];
                }
            }
            else
            {
                TempData["FailAudit"] = "ورودی نامعتبر است.";
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetCarModel(int carManufactureID)
        {
            var list = carModelRepository.GetList(carManufactureID).Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.ID.ToString()
            }).OrderBy(x => x.Text).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarYear(int carModelID)
        {
            var list = carYearRepository.GetList(carModelID).Select(x => new SelectListItem
            {
                Text = x.Year.ToString(),
                Value = x.ID.ToString()
            }).OrderBy(x => x.Text).ToList();
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
                }).OrderBy(x => x.Text).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPrice(int CarModelID, int CarYearID, int CarDetailID)
        {
            var item = carModelYearDetailRepository.GetPrice(CarModelID, CarYearID, CarDetailID);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
