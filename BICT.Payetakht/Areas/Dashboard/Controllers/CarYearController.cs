﻿using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    public class CarYearController : Controller
    {
        private CarYearRepository repository;

        public CarYearController()
        {
            repository = new CarYearRepository();
        }

        public ActionResult Index()
        {
            var list = repository.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarYearViewModel model)
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
        public ActionResult Edit(int ID, CarYearViewModel carYearViewModel)
        {
            repository.Edit(carYearViewModel);

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