using System.IO;
using System.Linq;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;

namespace BICT.Payetakht.Controllers
{
    public class InspectionController : Controller
    {
        private AuditRepository auditRepository;

        public InspectionController()
        {
            auditRepository = new AuditRepository();
        }

        public ActionResult Index(int p = 1)
        {
            ViewBag.Page = p;
            var list = auditRepository.GetInspectionList(p);
            foreach (var item in list)
            {
                var defaultPic = auditRepository.GetDefaultPicture(item.AuditID);
                if (!string.IsNullOrWhiteSpace(defaultPic))
                {
                    item.CoverPic = defaultPic;
                }
                else
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
            }
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            ViewBag.AuditID = id;
            var item = auditRepository.GetInspection(id);
            var path = Server.MapPath("~/Content/Audit/" + id);
            if (Directory.Exists(path))
            {
                item.Pictures = Directory.GetFiles(path).Select(x => Path.GetFileName(x)).ToList();
            }
            return View(item);
        }
    }
}
