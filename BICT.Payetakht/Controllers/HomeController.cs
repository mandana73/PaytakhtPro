namespace BICT.Payetakht.Controllers
{
    using System.Web.Mvc;
    using BICT.Payetakht.Data.Repository;

    public class HomeController : Controller

    {
      private  PictureOfSlideRepository repository;

        public HomeController()

        {
            repository = new PictureOfSlideRepository();
        }

        public ActionResult Index()
        {
            var List = repository.GetList();
            return View(List);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
