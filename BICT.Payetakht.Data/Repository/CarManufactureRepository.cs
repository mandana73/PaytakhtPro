using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class CarManufactureRepository : BaseRepository
    {
        public IList<CarManufactureViewModel> GetList()
        {
            return db.CarManufacturers
                     .Select(x => new CarManufactureViewModel
                     {
                         ID = x.ID,
                         Title = x.Title
                     })
                     .ToList();
        }
      public CarManufactureViewModel GetItem(int id)
        {
            return db.CarManufacturers.Where(x=>x.ID==id)
                .Select(x => new CarManufactureViewModel
                {
                    ID = x.ID,
                    Title = x.Title,

                }).FirstOrDefault();
        }

        public void Create(CarManufactureViewModel model)
        {
            var item = new CarManufacturer { Title = model.Title };
            db.CarManufacturers.Add(item);
            db.SaveChanges();
            
        }
        public void Edit(CarManufactureViewModel carManufactureView)
        {
           CarManufacturer  a = db.CarManufacturers.Find(carManufactureView.ID);
            a.Title = carManufactureView.Title;
            db.SaveChanges();
        }
        public void Delet(int ID)
        {
            var a = db.CarManufacturers.Find(ID);
            db.CarManufacturers.Remove(a);
            db.SaveChanges();
        }
        
    }
}
