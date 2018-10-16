using System.Linq;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    public class CarDetailController : Controller
    {
        private CarModelRepository carModelRepository;
        private CarDetailRepository repository;

        public CarDetailController()
        {
            carModelRepository = new CarModelRepository();
            repository = new CarDetailRepository();
        }

        public ActionResult Index()
        {
            var list = repository.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var list = ViewBag.CarModelList = carModelRepository.GetList()
                            .Select(x => new SelectListItem
                            {
                                Text = x.CarManufactureTitle + " - " + x.Title,
                                Value = x.ID.ToString()

                            }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.ModelList = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarDetailViewModel carDetailcarDetailView)
        {
            repository.Create(carDetailcarDetailView);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var b = repository.GetItem(ID);
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(int ID, CarDetailViewModel carDetailViewModel)
        {
            repository.Edit(carDetailViewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            repository.Delete(ID);
            return RedirectToAction(nameof(Index));
        }
    }
}
