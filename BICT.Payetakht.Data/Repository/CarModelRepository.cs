using System;
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
                   Title = x.Title,
                   CarManufactureTitle = x.CarManufacturer.Title
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
            var item = new CarModel
            {
                Title = car.Title,
                CarManufacturerID = car.CarManufacturerID
            };
            db.CarModels.Add(item);
            db.SaveChanges();
        }

        public void Edit(CarModelViewModel carModelView)
        {
            CarModel a = db.CarModels.Find(carModelView.ID);
            a.Title = carModelView.Title;
            db.SaveChanges(); 
        }

        public void Delete(int ID)
        {
            var a = db.CarModels.Find(ID);
            db.CarModels.Remove(a);
            db.SaveChanges();
        }

        public IList<CarModelViewModel> GetList(int carManufactureID)
        {
            return db.CarModels.Where(x=>x.CarManufacturerID == carManufactureID)
               .Select(x => new CarModelViewModel
               {
                   ID = x.ID,
                   Title = x.Title,
                   CarManufactureTitle = x.CarManufacturer.Title
               })
                .ToList();
        }
        public bool CheckDuplicate(string Title, int? id = null)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                return false;
            }
            string title = Title.Replace(" ", "").Trim();
            List<CarModel> carModelsList;
            if (id != null)
            {
                carModelsList = db.CarModels.Where(x => x.ID != id).ToList();
            }
            else
            {
                carModelsList = db.CarModels.ToList();
            }
            foreach (var item in carModelsList)
            {
                string Model = item.Title.Replace(" ", "").Trim();
                if (Model == title)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
