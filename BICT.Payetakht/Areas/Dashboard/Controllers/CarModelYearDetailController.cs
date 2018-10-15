using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    public class CarModelYearDetailController : Controller
    {
        private CarModelYearDetailRepository repository;

        public CarModelYearDetailController()
        {
            repository = new CarModelYearDetailRepository();
        }

        public ActionResult Index()
        {
            var list = repository.GetList();
            return View(list);
        }
    }
}
