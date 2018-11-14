using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;
using BICT.Payetakht.Helper;

namespace BICT.Payetakht.Areas.Dashboard.Controllers
{
    [Authorize]
    public class PictureOfSlideController : Controller
    {
        private PictureOfSlideRepository repository;

        public PictureOfSlideController()
        {
            repository = new PictureOfSlideRepository();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Index(int p = 1)
        {
            ViewBag.Page = p;
            var list = repository.GetPagedList(p, 10);
            return View(list);
        }
        [HttpPost]
        public ActionResult Create(IEnumerable<HttpPostedFileBase> files)
        {
            var path = Server.MapPath("~/Content/SlideImage");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            int index = 1;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        if (!Util.CheckFormat(file.FileName, "png", "jpg", "jpeg"))
                        {
                            continue;
                        }
                        var ext = Path.GetExtension(file.FileName);
                        var filePath = path + "/" + index + ext;
                        while (System.IO.File.Exists(filePath))
                        {
                            index++;
                            filePath = path + "/" + index + ext;
                        }

                        var Name = "~/Content/SlideImage/" + index + ext;
                        file.SaveAs(filePath);
                        repository.Create(Name);
                        index++;
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var path =            repository.Delete(id);
            if (System.IO.File.Exists(Server.MapPath(path)))
            {
                System.IO.File.Delete(Server.MapPath(path));
            }
            return RedirectToAction("Index");
        }
    }
}
