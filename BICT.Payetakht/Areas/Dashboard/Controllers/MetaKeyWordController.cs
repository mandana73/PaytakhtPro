using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class MetaKeyWordController : Controller
    {
        private MetaKeyWordRepository repository;

        public MetaKeyWordController()
        {
            repository = new MetaKeyWordRepository();
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
        public ActionResult Create(MetaKeyWordViewModel model)
        {
            var Model = repository.CheckDuplicate(model.Title);
            if (Model)
            {
                ViewBag.ErrorMessage = "عنوان وارد شده تکراریست";
                return View();
            }
            repository.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var b = repository.GetItem(ID);

            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(int ID, MetaKeyWordViewModel MetaKeyWordViewModel)
        {
            repository.Edit(MetaKeyWordViewModel);

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
