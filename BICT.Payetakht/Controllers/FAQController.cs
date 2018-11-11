namespace BICT.Payetakht.Controllers
{
    using System.Web.Mvc;
    using BICT.Payetakht.Data.Repository;

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
            var list = repository.GetPagedList(p, 5);
            return View(list);
        }
    }
}
