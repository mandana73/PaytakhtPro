namespace BICT.Payetakht.Controllers
{
    using System.Web.Mvc;
    using BICT.Payetakht.Data.Repository;

    public class ReadingsController : Controller
        {
            private ReadingsRepository repository;

            public ReadingsController()
            {
                repository = new ReadingsRepository();
            }

            public ActionResult Index()
            {
                var list = repository.GetList();
                return View(list);
            }
        }
    
}
