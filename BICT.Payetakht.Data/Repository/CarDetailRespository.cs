using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class CarDetailRepository : BaseRepository
    {
        public IList<CarDetailViewModel> GetList()
        {
            return db.CarDetails
                     .Select(x => new CarDetailViewModel
                     {
                         ID = x.ID,
                         CarModelTitle = x.CarModel.Title,
                         CarModelID = x.CarModelID,
                         CarManufactureTitle = x.CarModel.CarManufacturer.Title,
                         Title = x.Title,
                     }).ToList();
        }
        public IList<CarDetailViewModel> GetList(int carModelID)
        {
            return db.CarDetails.Where(x => x.CarModelID == carModelID)
                     .Select(x => new CarDetailViewModel
                     {
                         ID = x.ID,
                         CarModelTitle = x.CarModel.Title,
                         CarModelID = x.CarModelID,
                         CarManufactureTitle = x.CarModel.CarManufacturer.Title,
                         Title = x.Title,
                     }).ToList();
        }

        public CarDetailViewModel GetItem(int id)
        {
            return db.CarDetails.Where(x => x.ID == id)
                .Select(x => new CarDetailViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    CarModelID = x.CarModelID,
                }).FirstOrDefault();
        }

        public void Create(CarDetailViewModel carDetail)
        {
            var item = new CarDetail()
            {
                Title = carDetail.Title,
                CarModelID = carDetail.CarModelID,
            };
            db.CarDetails.Add(item);
            db.SaveChanges();
        }

        public void Edit(CarDetailViewModel carDetailView)
        {
            CarDetail carDetail = db.CarDetails.Find(carDetailView.ID);
            carDetail.Title = carDetailView.Title;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var carDetail = db.CarDetails.Find(ID);
            db.CarDetails.Remove(carDetail);
            db.SaveChanges();
        }
    }
}
