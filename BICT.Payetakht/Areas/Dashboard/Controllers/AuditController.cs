using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Helper;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class AuditController : Controller
    {
        private AuditRepository auditRepository;

        public AuditController()
        {
            auditRepository = new AuditRepository();
        }

        public ActionResult Index()
        {
            var audits = auditRepository.GetList();
            return View(audits);
        }

        public ActionResult Detail(int id)
        {
            var audit = auditRepository.Getitem(id);
            audit.RequestDatePersian = new PersianDateTime(audit.RequestDate).ToString();
            return View(audit);
        }

        public ActionResult SetAsDone(int id)
        {
            var audit = auditRepository.Getitem(id);
            if(audit ==null )
            {
                ViewBag.Error = "آیتم انتخاب نشده است";
            return RedirectToAction(nameof (Index));
            }
            auditRepository.SetAsDone(id);
            return RedirectToAction(nameof(Index));


        }
    }
}
