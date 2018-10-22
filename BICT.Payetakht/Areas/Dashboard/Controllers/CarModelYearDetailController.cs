using System.Linq;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class CarModelYearDetailController : Controller
    {
        private CarModelYearDetailRepository repository;
        private CarModelRepository carModelRepository;
        private CarYearRepository carYearRepository;
        private CarDetailRepository carDetailRepository;

        public CarModelYearDetailController()
        {
            repository = new CarModelYearDetailRepository();
            carModelRepository = new CarModelRepository();
            carYearRepository = new CarYearRepository();
            carDetailRepository = new CarDetailRepository();
        }

        public ActionResult Index(int p =1)
        {
            ViewBag.Page = p;
            var list = repository.GetPagedList(p);
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                var List = carModelRepository.GetList()
                          .Select(x => new SelectListItem
                          {
                              Text = x.CarManufactureTitle + " - " + x.Title,
                              Value = x.ID.ToString()
                          }).ToList();
                List.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
                ViewBag.CarModelList = List;
                return View();
            }
            var list = carModelRepository.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CarManufactureTitle + " - " + x.Title,
                    Value = x.ID.ToString()
                }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.ModelList = list;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                var List = carModelRepository.GetList()
                          .Select(x => new SelectListItem
                          {
                              Text = x.CarManufactureTitle + " - " + x.Title,
                              Value = x.ID.ToString()
                          }).ToList();
                List.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
                ViewBag.CarModelList = List;
                return View();
            }
            var list = carModelRepository.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CarManufactureTitle + " - " + x.Title,
                    Value = x.ID.ToString()
                }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.ModelList = list;
            var item = repository.GetItem(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(CarModelYearDetailViewModel model)
        {
            repository.Edit(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var item = repository.GetItem(id);
            if (item!= null)
            {
            repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
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
        [HttpPost]
        public ActionResult Create(CarModelYearDetailViewModel car)
        {
            repository.Create(car);
            return RedirectToAction("Index");
        }

    }
}
