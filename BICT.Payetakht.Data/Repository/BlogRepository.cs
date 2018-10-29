using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class BlogRepository : BaseRepository
    {
        public IList<BlogViewModel> GetList()
        {
            return db.Blogs
                .Select(x => new BlogViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                     Content=x.Content,
                      CreateDateTime=x.CreateDateTime,
                })
                .ToList();
        }

        public IList<BlogViewModel> GetPagedList(int pageNum)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * 5;
            return db.Blogs
                     .OrderByDescending(x => x.ID)
                     .Skip(skip)
                     .Take(5)
                     .Select(x => new BlogViewModel
                     {
                         ID = x.ID,
                         Title = x.Title,
                         Content = x.Content,
                         CreateDateTime = x.CreateDateTime,
                     })
                     .ToList();
        }
        public BlogViewModel GetItem(int id)
        {
            return db.Blogs.Where(x => x.ID == id)
                .Select(x => new BlogViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                     CreateDateTime=x.CreateDateTime,
                      Content=x.Content,
                }).FirstOrDefault();
        }

        public void Create(BlogViewModel Blog)
        {
            var item = new Blog { Title = Blog.Title, CreateDateTime = DateTime.Now };
            db.Blogs.Add(item);
            db.SaveChanges();
        }

        public void Edit(BlogViewModel BlogView)
        {
            var a = db.Blogs.Find(BlogView.ID);
            a.Title = BlogView.Title;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var a = db.Blogs.Find(ID);
            db.Blogs.Remove(a);
            db.SaveChanges();
        }
    }
}
