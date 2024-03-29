﻿using System.Collections.Generic;
using System.Linq;
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
        public bool CheckDuplicate(CarModelYearDetailViewModel model, int? id)
        {
            if (model == null)
            {
                return false;
            }
            if (id != null)
            {
                return db.CarModelYearDetails.Any(x => x.ID != id && x.CarYearID == model.CarYearID && x.CarModelID == model.CarModelID && x.CarDetailID == model.CarDetailID);
            }
            else
            {
                return db.CarModelYearDetails.Any(x => x.CarYearID == model.CarYearID && x.CarModelID == model.CarModelID && x.CarDetailID == model.CarDetailID);
            }
        }

        public IList<CarModelYearDetailViewModel> GetPagedList(int pageNum, int CarModelID = 0, int CarYearID = 0, int CarDetailID = 0)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * 10;
            var query = db.CarModelYearDetails.AsQueryable();
            if (CarModelID > 0)
            {
                query = query.Where(x => x.CarModelID == CarModelID);
            }
            if (CarYearID > 0)
            {
                query = query.Where(x => x.CarYearID == CarYearID);
            }
            if (CarDetailID > 0)
            {
                query = query.Where(x => x.CarDetailID == CarDetailID);
            }
            return query.OrderByDescending(x => x.ID).Skip(skip)
              .Take(10)
              .Select(x => new CarModelYearDetailViewModel
              {
                  ID = x.ID,
                  CarDetailID = x.CarDetailID,
                  CarDetailTitle = x.CarDetail.Title,
                  CarModelID = x.CarModelID,
                  CarModelTitle = x.CarModel.CarManufacturer.Title + " - " + x.CarModel.Title,
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
            if (item != null)
            {
                return item.Price;
            }
            return 0;
        }
    }
}
