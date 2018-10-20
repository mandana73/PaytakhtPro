namespace BICT.Payetakht.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using BICT.Payetakht.Data.Repository;
    using BICT.Payetakht.Data.ViewModels;

    public class AuditController : Controller
    {
        private CarManufactureRepository carManufactureRepository;
        private CityRepository cityRepository;
        private CarModelRepository carModelRepository;
        private CarYearRepository carYearRepository;
        private CarDetailRepository carDetailRepository;
        private CarModelYearDetailRepository carModelYearDetailRepository;
        private AuditRepository auditRepository;

        public AuditController()
        {
            carManufactureRepository = new CarManufactureRepository();
            cityRepository = new CityRepository();
            carModelRepository = new CarModelRepository();
            carYearRepository = new CarYearRepository();
            carDetailRepository = new CarDetailRepository();
            carModelYearDetailRepository = new CarModelYearDetailRepository();
            auditRepository = new AuditRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
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

            return View();
        }

        [HttpPost]
        public ActionResult Index(AuditViewModel audit)
        {
            auditRepository.Create(audit);
            return View();
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

        public JsonResult GetPrice(int CarModelID, int CarYearID, int CarDetailID)
        {
            var item = carModelYearDetailRepository.GetPrice(CarModelID, CarYearID, CarDetailID);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
