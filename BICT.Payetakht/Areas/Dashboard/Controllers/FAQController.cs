using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    public class FAQController : Controller
    {
        private FAQRepository repository;

        public FAQController()
        {
            repository = new FAQRepository();
        }

        public ActionResult Index(int p = 1)
        {
            ViewBag.Page = p;
            var list = repository.GetPagedList(p, 10);
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FAQViewModel fAQ)
        {
            repository.Create(fAQ);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var b = repository.GetItem(ID);

            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(int ID, FAQViewModel FAQViewModel)
        {
            repository.Edit(FAQViewModel);

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
