namespace BICT.Payetakht.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using BICT.Payetakht.Data.Repository;

    public class AuditController : Controller
    {
        private CarManufactureRepository carManufactureRepository;
        private CityRepository cityRepository;
        private CarModelRepository carModelRepository;
        private CarYearRepository carYearRepository;
        private CarDetailRepository carDetailRepository;

        public AuditController()
        {
            carManufactureRepository = new CarManufactureRepository();
            cityRepository = new CityRepository();
            carModelRepository = new CarModelRepository();
            carYearRepository = new CarYearRepository();
            carDetailRepository = new CarDetailRepository();
        }


        public ActionResult Index()
        {
            var mlist = carManufactureRepository.GetList()
                 .Select(x => new SelectListItem
                 {
                     Text =x.Title,
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


            return View(list);
        }

        public JsonResult GetCarModel(int carManufactureID)
        {
            var list = carModelRepository.GetList(carManufactureID).Select(x => new SelectListItem
            {
                
                Text=x.Title,
                Value = x.ID.ToString()
            }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCarYear(int carModelID)
        {
            var list = carYearRepository.GetList(carModelID).Select(x => new SelectListItem
            {
  
                Text=x.Year.ToString(),
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

