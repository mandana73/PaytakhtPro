using System;
using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class CommentRepository : BaseRepository
    {
        public IList<CommentViewModel> GetList()
        {
            return db.Comments
                .Select(x => new CommentViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Title = x.Title,

                    CreateDateTime = x.CreateDateTime,
                }).ToList();
        }

        public IList<CommentViewModel> GetPagedList(int pageNum, int pageSize)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * pageSize;
            return db.Comments
                     .OrderByDescending(x => x.ID)
                     .Skip(skip)
                     .Take(pageSize)
                     .Select(x => new CommentViewModel
                     {
                         ID = x.ID,
                         Name = x.Name,
                         Phone = x.Phone,
                         Email = x.Email,
                         Title = x.Title,
                         CreateDateTime = x.CreateDateTime,
                         IsConfirm=x.IsConfirm,
                     }).ToList();
        }

        public CommentViewModel GetItem(int id)
        {
            return db.Comments.Where(x => x.ID == id)
                .Select(x => new CommentViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Title = x.Title,
                    CreateDateTime = x.CreateDateTime,
                }).FirstOrDefault();
        }

        public void Create(CommentViewModel comment)
        {
            var item = new Comment
            {
                Name = comment.Name,
                Email = comment.Email,
                Phone = comment.Phone,
                Title = comment.Title,
                IsConfirm=comment.IsConfirm,
                CreateDateTime = DateTime.Now
            };
            db.Comments.Add(item);
            db.SaveChanges();
        }

        //public void Edit(CommentViewModel CommentView)
        //{
        //    var a = db.Comments.Find(CommentView.ID);
        //    a.Name = CommentView.Name;
        //    a.Email = CommentView.Email;
        //    a.Phone = CommentView.Phone;
        //    db.SaveChanges();
        //}

        public void Delete(int ID)

        {
            var a = db.Comments.Find(ID);
            db.Comments.Remove(a);
            db.SaveChanges();
        }

        public IList<CommentViewModel> GetLatestComment(int Show)
        {
            return db.Comments
                .Where(x=>x.IsConfirm==true)
               .OrderByDescending(x => x.ID)
               .Take(Show)
               .Select(x => new CommentViewModel
               {
                   ID = x.ID,
                   Name = x.Name,
                   Title = x.Title,
                   Email = x.Email,
                   Phone = x.Phone,
                   CreateDateTime = x.CreateDateTime,
               }).ToList();
               
        }

        public void Confirm(int ID)
        {
            var x = db.Comments.Find(ID);
            x.IsConfirm = true;
            db.SaveChanges();
        }
    }
}
