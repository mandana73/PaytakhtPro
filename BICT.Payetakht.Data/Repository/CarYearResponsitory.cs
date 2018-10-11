using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;


namespace BICT.Payetakht.Data.Repository
{
    public class CarYearRepository : BaseRepository
    {
        public IList<CarYearViewModel> GetList()
        {
            return db.CarYears
                     .Select(x => new CarYearViewModel
                     {
                         ID = x.ID,
                        Year = x.Year
                     })
                     .ToList();
        }
        public CarYearViewModel GetItem(int id)
        {
            return db.CarYears.Where(x => x.ID == id)
                .Select(x => new CarYearViewModel
                {
                    ID = x.ID,
                    Year = x.Year,

                }).FirstOrDefault();
        }

        public void Create(CarYearViewModel CarYear)
        {
            var item = new CarYear { Year = CarYear.Year };
            db.CarYears.Add(item);
            db.SaveChanges();

        }
        public void Edit(CarYearViewModel carYearView)
        {
            CarYear a = db.CarYears.Find(carYearView.ID);
            a.Year = carYearView.Year;
            db.SaveChanges();
        }
        public void Delete(int ID)
        {
            var a = db.CarYears.Find(ID);
            db.CarYears.Remove(a);
            db.SaveChanges();
        }

    }
}
