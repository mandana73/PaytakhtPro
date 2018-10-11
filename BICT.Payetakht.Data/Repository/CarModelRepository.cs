using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class CarModelRepository : BaseRepository
    {
        public IList<CarModelViewModel> GetList()
        {
            return db.CarModels
               .Select(x => new CarModelViewModel
               {
                   ID = x.ID,
                   Title = x.Title
               })
                .ToList();
        }

        public CarModelViewModel GetItem(int id)
        {
            return db.CarModels.Where(x => x.ID == id)
                .Select(x => new CarModelViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                }).FirstOrDefault();
        }

        public void Create(CarModelViewModel car)
        {
            var item = new CarModels { Title = car.Title };
            db.CarModels.Add(item);
            db.SaveChanges();
        }

        public void Edit(CarModelViewModel carModelView)
        {
            CarModels a = db.CarModels.Find(carModelView.ID);
            a.Title = carModelView.Title;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var a = db.CarModels.Find(ID);
            db.CarModels.Remove(a);
            db.SaveChanges();
        }
    }
}
