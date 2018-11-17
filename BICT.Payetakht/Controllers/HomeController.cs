namespace BICT.Payetakht.Controllers
{
    using System.IO;
    using System.Web.Mvc;
    using BICT.Payetakht.Data.Repository;
    using BICT.Payetakht.Data.ViewModels;

    public class HomeController : Controller
    {
        private PictureOfSlideRepository repository;
        private AuditRepository auditrepository;


        public HomeController()
        {
            repository = new PictureOfSlideRepository();
            auditrepository = new AuditRepository();
        }

        public ActionResult Index()
        {
            var x = new HomeViewModel
            {
                Inspections = auditrepository.GetLatestInspection(4),
                Slide = repository.GetList()
            };
            foreach (var item in x.Inspections)
            {
                var path = Server.MapPath("~/Content/Audit/" + item.AuditID);
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);
                    if (files.Length > 0)
                    {
                        item.CoverPic = Path.GetFileName(files[0]);
                    }
                }
            }
            return View(x);
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
