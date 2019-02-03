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
        private CommentRepository commentRepository;

        public HomeController()
        {
            repository = new PictureOfSlideRepository();
            auditrepository = new AuditRepository();
            commentRepository = new CommentRepository();
        }

        public ActionResult Index()
        {
            var x = new HomeViewModel
            {
                Inspections = auditrepository.GetLatestInspection(4),
                Comments = commentRepository.GetLatestComment(4),
                Slide = repository.GetList()
            };
            foreach (var item in x.Inspections)
            {
                var DefaultPic = auditrepository.GetDefaultPicture(item.AuditID);
                if (!string.IsNullOrWhiteSpace(DefaultPic))
                {
                    item.CoverPic = DefaultPic;
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

            return View(x);
        }

        [HttpGet]
        public ActionResult Comment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Comment(CommentViewModel comment)
        {
            var x = new CommentViewModel()
            {
                Name = comment.Name,
                Title = comment.Title,
                Phone = comment.Phone,
                Email = comment.Email,
                IsConfirm = false,
            };
            commentRepository.Create(x);
            return Redirect("Index");
        }
    }
}
