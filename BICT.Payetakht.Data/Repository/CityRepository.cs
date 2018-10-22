using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class CityRepository : BaseRepository
    {
        public IList<CityViewModel> GetList()
        {
            return db.Cities
                .Select(x => new CityViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                })
                .ToList();
        }

        public IList<CityViewModel> GetPagedList( int pageNum )
        {
            if (pageNum<1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * 10;
            return db.Cities
                     .OrderByDescending(x=>x.ID)
                     .Skip(skip)
                     .Take(10)
                     .Select(x => new CityViewModel
                      {
                          ID = x.ID,
                          Title = x.Title,
                     })
                     .ToList();
        }
        public CityViewModel GetItem(int id)
        {
            return db.Cities.Where(x => x.ID == id)
                .Select(x => new CityViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                }).FirstOrDefault();
        }

        public void Create(CityViewModel Cities)
        {
            var item = new City { Title = Cities.Title };
            db.Cities.Add(item);
            db.SaveChanges();
        }

        public void Edit(CityViewModel CityView)
        {
            var a = db.Cities.Find(CityView.ID);
            a.Title = CityView.Title;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var a = db.Cities.Find(ID);
            db.Cities.Remove(a);
            db.SaveChanges();
        }
    }
}
