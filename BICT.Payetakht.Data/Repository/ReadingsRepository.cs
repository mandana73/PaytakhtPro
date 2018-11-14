using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{

    public class ReadingsRepository : BaseRepository
    {
        public IList<ReadingsViewModel> GetList()
        {
            return db.Reads
                .Select(x => new ReadingsViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Content = x.Content,
                })
                .ToList();
        }

        public IList<ReadingsViewModel> GetPagedList(int pageNum, int pageSize)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * pageSize;
            return db.Reads
                     .OrderByDescending(x => x.ID)
                     .Skip(skip)
                     .Take(pageSize)
                     .Select(x => new ReadingsViewModel
                     {
                         ID = x.ID,
                         Title = x.Title,
                          Content=x.Content,
                     })
                     .ToList();
        }

        public ReadingsViewModel GetItem(int id)
        {
            return db.Reads.Where(x => x.ID == id)
                .Select(x => new ReadingsViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Content = x.Content,
                }).FirstOrDefault();
        }

        public void Create(ReadingsViewModel Read)
        {
            var item = new Readings
            {
                Title = Read.Title,
                Content = Read.Content,
            };
            db.Reads.Add(item);
            db.SaveChanges();
        }

        public void Edit(ReadingsViewModel ReadView)
        {
            var a = db.Reads.Find(ReadView.ID);
            a.Title = ReadView.Title;
            a.Content = ReadView.Content;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var a = db.Reads.Find(ID);
            db.Reads.Remove(a);
            db.SaveChanges();
        }
    }
}
