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
            return db.CarManufacturers.Where(x => x.ID == id)
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
            CarManufacturer a = db.CarManufacturers.Find(carManufactureView.ID);
            a.Title = carManufactureView.Title;
            db.SaveChanges();
        }
        public void Delete(int ID)
        {
            var carManufacturer = db.CarManufacturers.Find(ID);
            db.CarManufacturers.Remove(carManufacturer);
            db.SaveChanges();
        }
        public bool CheckDuplicate(string Title, int? id = null)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                return false;
            }
            string title = Title.Replace(" ", "").Trim();
            List<CarManufacturer> carManufacturersList;
            if (id != null)
            {
                carManufacturersList = db.CarManufacturers.Where(x => x.ID != id).ToList();
            }
            else
            {
                carManufacturersList = db.CarManufacturers.ToList();
            }
            foreach (var item in carManufacturersList)
            {
                string Manufacture = item.Title.Replace(" ", "").Trim();
                if (Manufacture == title)
                {
                    return true;
                }
            }
            return false;
        }

        public int CarManufactureCount()
        {
            return db.CarManufacturers.Count();
        }

    }
}

