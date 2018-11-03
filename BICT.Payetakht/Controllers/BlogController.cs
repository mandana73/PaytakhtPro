using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;

namespace BICT.Payetakht.Controllers
{
    public class BlogController : Controller
    {
        private BlogRepository repository;
        public BlogController()
        {
            repository = new BlogRepository();
        }
        public ActionResult Index(int p=1)
        {
            ViewBag.Page = p;
            var list = repository.GetPagedList(p,5);
            return View(list);
        }
        public ActionResult Post(int id)
        {
            var a = repository.GetItem(id);
            return View (a);
        }
    }
}