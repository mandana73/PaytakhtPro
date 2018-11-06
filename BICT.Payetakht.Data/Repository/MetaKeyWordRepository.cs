using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;
using BICT.Payetakht.Helper;

namespace BICT.Payetakht.Data.Repository
{
    public class MetaKeyWordRepository : BaseRepository
    {
        public IList<MetaKeyWordViewModel> GetList()
        {
            return db.MetaKeyWords
                .Select(x => new MetaKeyWordViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                })
                .ToList();
        }

        public IList<MetaKeyWordViewModel> GetPagedList(int pageNum)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * 10;
            return db.MetaKeyWords
                     .OrderByDescending(x => x.ID)
                     .Skip(skip)
                     .Take(10)
                     .Select(x => new MetaKeyWordViewModel
                     {
                         ID = x.ID,
                         Title = x.Title,
                     })
                     .ToList();
        }

        public MetaKeyWordViewModel GetItem(int id)
        {
            return db.MetaKeyWords.Where(x => x.ID == id)
                .Select(x => new MetaKeyWordViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                }).FirstOrDefault();
        }

        public void Create(MetaKeyWordViewModel Cities)
        {
            var item = new MetaKeyWord { Title = Util.RemoveMultiSpaces(Cities.Title) };
            db.MetaKeyWords.Add(item);
            db.SaveChanges();
        }

        public void Edit(MetaKeyWordViewModel CityView)
        {
            var a = db.MetaKeyWords.Find(CityView.ID);
            a.Title = CityView.Title;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var a = db.MetaKeyWords.Find(ID);
            db.MetaKeyWords.Remove(a);
            db.SaveChanges();
        }

        public bool CheckDuplicate(string Title, int? id = null)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                return false;
            }
            string title = Util.RemoveMultiSpaces(Title, true).Trim();
            List<MetaKeyWord> MetaKeyWordList;
            if (id != null)
            {
                MetaKeyWordList = db.MetaKeyWords.Where(x => x.ID != id).ToList();
            }
            else
            {
                MetaKeyWordList = db.MetaKeyWords.ToList();
            }
            foreach (var item in MetaKeyWordList)
            {
                string Model = Util.RemoveMultiSpaces(item.Title).Trim();
                if (Model == title)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
