using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class CarModelYearDetailRepository : BaseRepository
    {
        public IList<CarModelYearDetailViewModel> GetList()
        {
            return db.CarModelYearDetails
                .Select(x => new CarModelYearDetailViewModel
                {
                    ID = x.ID,
                    CarDetailID = x.CarDetailID,
                    CarDetailTitle = x.CarDetail.Title,
                    CarModelID = x.CarModelID,
                    CarModelTitle = x.CarModel.Title,
                    CarYearID = x.CarYearID,
                    CarYearTitle = x.CarYear.Year,
                    Price = x.Price,

                }).ToList();

        }
        public CarModelYearDetailViewModel GetItem(int id)
        {
            return db.CarModelYearDetails.Where(x => x.ID == id)
                .Select(x => new CarModelYearDetailViewModel
                {
                    ID = x.ID,
                    CarDetailID = x.CarDetailID,
                    CarDetailTitle = x.CarDetail.Title,
                    CarModelID = x.CarModelID,
                    CarModelTitle = x.CarModel.Title,
                    CarYearID = x.CarYearID,
                    CarYearTitle = x.CarYear.Year,
                    Price = x.Price,
                }).FirstOrDefault();

        }
        public void Create(CarModelYearDetailViewModel carModelYearDetailView)
        {
            var item = new CarModelYearDetail
            {
                CarDetailID = carModelYearDetailView.CarDetailID,
                CarModelID = carModelYearDetailView.CarModelID,
                CarYearID = carModelYearDetailView.CarYearID,
                Price = carModelYearDetailView.Price,
            };
            db.CarModelYearDetails.Add(item);
            db.SaveChanges();
        }
        public void Edit(CarModelYearDetailViewModel carModelYearDetailView)
        {

            CarModelYearDetail a = db.CarModelYearDetails.Find(carModelYearDetailView.ID);
            a.CarYearID = carModelYearDetailView.CarYearID;
            a.CarModelID = carModelYearDetailView.CarModelID;
            a.CarDetailID = carModelYearDetailView.CarDetailID;
            a.Price = carModelYearDetailView.Price;


            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var a = db.CarModelYearDetails.Find(ID);
            db.CarModelYearDetails.Remove(a);
            db.SaveChanges();
        }

        public int GetPrice(int CarModelID, int CarYearID, int CarDetailID)
        {
            var item = db.CarModelYearDetails.Where(x => x.CarModelID == CarModelID &&
                                                x.CarDetailID == CarDetailID &&
                                                x.CarYearID == CarYearID).FirstOrDefault();
            if (item != null) {
                return item.Price;
            }
            return 0;
        }

    }


}



