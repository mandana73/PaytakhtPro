using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private CommentRepository repository;

        public CommentController()
        {
            repository = new CommentRepository();
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
        public ActionResult Create(CommentViewModel Comment)
        {
            Comment.IsConfirm = true;
            repository.Create(Comment);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            repository.Delete(ID);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Confirm(int ID)
        {
            repository.Confirm(ID);
            return RedirectToAction(nameof(Index));
        }


    }
}
