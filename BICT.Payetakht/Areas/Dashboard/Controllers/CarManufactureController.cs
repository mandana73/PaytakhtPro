﻿using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class CarManufactureController : Controller
    {
        private CarManufactureRepository repository;

        public CarManufactureController()
        {
            repository = new CarManufactureRepository();
        }

        public ActionResult Index(int p = 1)
        {
            ViewBag.Page = p;
            var list = repository.GetPagedList(p);
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarManufactureViewModel model)
        {
            var Manufacture = repository.CheckDuplicate(model.Title);
            if (Manufacture)
            {
                ViewBag.ErrorMessage = "عنوان وارد شده تکراریست";
                return View();
            }
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
        public ActionResult Edit(int ID, CarManufactureViewModel carManufactureViewModel)
        {
            var Manufacture = repository.CheckDuplicate(carManufactureViewModel.Title, ID);
            if (Manufacture)
            {
                ViewBag.ErrorMessage = "عنوان وارد شده تکراریست";
                return View();
            }
            repository.Edit(carManufactureViewModel);
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
