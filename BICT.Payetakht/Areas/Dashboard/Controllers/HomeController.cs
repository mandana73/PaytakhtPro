using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private CarManufactureRepository carManufactureRepository;
        private CarModelRepository carModelRepository;
        private AuditRepository auditRepository;
        private CarDetailRepository carDetailRepository;

        public HomeController()
        {
            auditRepository = new AuditRepository();
            carManufactureRepository = new CarManufactureRepository();
            carModelRepository = new CarModelRepository();
            carDetailRepository = new CarDetailRepository();
        }

        public ActionResult Index()
        {
            var model = new DashboardViewModel();
            model.AuditAllRequest = auditRepository.AllRequestCount();
            model.AuditUnDone = auditRepository.GetUnDoneCount();
            model.AuditUnRead = auditRepository.GetUnReadCount();
            model.CarManufactureCount = carManufactureRepository.CarManufactureCount();
            model.CarModelCount = carModelRepository.CarModelCount();
            model.CarDetailCount = carDetailRepository.CarDetailCount();
            return View(model);
        }
    }
}
