using System.Linq;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    public class CarDetailController : Controller
    {
        private CarYearRepository carYearRepository;
        private CarDetailRepository repository;

        public CarDetailController()
        {
            repository = new CarDetailRepository();
            carYearRepository = new CarYearRepository();
        }

        public ActionResult Index()
        {
            var list = repository.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CarYearsList = carYearRepository.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CarManufactureTitle + " - " + x,
                    Value = x.ID.ToString()

                }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarDetailViewModel model)
        {
            repository.Create(model);
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
