using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
   public class FAQRepository : BaseRepository
    {
        public IList<FAQViewModel> GetList()
        {
            return db.FAQs
                .Select(x => new FAQViewModel
                {
                    ID = x.ID,
                    Question = x.Question,
                    Answer=x.Answer,
                })
                .ToList();
        }


        public IList<FAQViewModel> GetPagedList(int pageNum, int pageSize)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * pageSize;
            return db.FAQs
                     .OrderByDescending(x => x.ID)
                     .Skip(skip)
                     .Take(pageSize)
                     .Select(x => new FAQViewModel
                     {
                         ID = x.ID,
                         Question = x.Question,
                         Answer = x.Answer,
                     })
                     .ToList();
        }

        public FAQViewModel GetItem(int id)
        {
            return db.FAQs.Where(x => x.ID == id)
                .Select(x => new FAQViewModel
                {
                    ID = x.ID,
                    Question = x.Question,
                    Answer = x.Answer,
                }).FirstOrDefault();
        }


        public void Create(FAQViewModel vm)
        {
            var item = new FAQ
            {
                 ID=vm.ID,
                Question = vm.Question,
               Answer = vm.Answer,
                
            };
            db.FAQs.Add(item);
            db.SaveChanges();
        }

        public void Edit(FAQViewModel FAQView)
        {
            var a = db.FAQs.Find(FAQView.ID);
            a.Question = FAQView.Question;
            a.Answer = FAQView.Answer;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var a = db.FAQs.Find(ID);
            db.FAQs.Remove(a);
            db.SaveChanges();
        }
    }

}
