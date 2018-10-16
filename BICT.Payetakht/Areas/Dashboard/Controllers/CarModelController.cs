using System.Linq;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    public class CarModelController : Controller
    {
        private CarManufactureRepository manufactureRepository;
        private CarModelRepository repository;

        public CarModelController()
        {
            repository = new CarModelRepository();
            manufactureRepository = new CarManufactureRepository();
        }

        public ActionResult Index()
        {
            var list = repository.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
           var list= ViewBag.ManufactureList = manufactureRepository.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.ID.ToString()
                }).ToList();
            list.Insert(0, new SelectListItem { Value = "", Text = "انتخاب نمایید" });
            ViewBag.ManufactureList = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarModelViewModel car)
        {
            repository.Create(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var b = repository.GetItem(ID);

            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(int ID, CarModelViewModel carModelViewModel)
        {
            repository.Edit(carModelViewModel);
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
