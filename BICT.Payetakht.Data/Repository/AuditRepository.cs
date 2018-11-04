using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;
using BICT.Payetakht.Helper;

namespace BICT.Payetakht.Data.Repository
{
    public class AuditRepository : BaseRepository
    {
        public void Create(AuditViewModel audit)
        {
            var cmydr = new CarModelYearDetailRepository();
            var item = new Audit()
            {
                CarManufactureID = audit.CarManufactureID,
                CarDetailID = audit.CarDetailID,
                CarYearID = audit.CarYearID,
                CarModelID = audit.CarModelID,
                RequestDate = PersianDateTime.Parse(audit.RequestDatePersian).ToDateTime(),
                FirstName = audit.FirstName,
                LastName = audit.LastName,
                Phone = audit.Phone,
                Price = cmydr.GetPrice(audit.CarModelID, audit.CarYearID, audit.CarDetailID),
                Email = audit.Email,
                PaymentDate = audit.PaymentDate,
                ReferID = audit.ReferID,
                Authority=audit.Authority,
                PaymentTypeID=audit.PaymentTypeID
            };
            db.Audit.Add(item);
            db.SaveChanges();
        }


        public ICollection<AuditViewModel> GetList()
        {
            return db.Audit
                .Select(x => new AuditViewModel
                {
                    ID = x.ID,
                    CarDetailID = x.CarDetailID,
                    CarDetailTitle = x.CarDetail.Title,
                    CarManufactureID = x.CarManufactureID,
                    CarManufactureTitle = x.CarManufacturer.Title,
                    CarModelID = x.CarModelID,
                    CarModelTitle = x.CarModel.Title,
                    CarYearTitle = x.CarYear.Year,
                    CarYearID = x.CarYearID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Email = x.Email,
                    Price = x.Price,
                    IsDone = x.IsDone,
                    IsRead = x.IsRead,
                    RequestDate = x.RequestDate,
                    Authority = x.Authority,
                    PaymentDate = x.PaymentDate,
                    PaymentTypeID = x.PaymentTypeID,
                    ReferID = x.ReferID,
                }).ToList();
        }

        public AuditViewModel Getitem(int id)
        {
            var a = db.Audit.Where(x => x.ID == id)
                     .Select(x => new AuditViewModel
                     {
                         ID = x.ID,
                         CarDetailID = x.CarDetailID,
                         CarDetailTitle = x.CarDetail.Title,
                         CarManufactureID = x.CarManufactureID,
                         CarManufactureTitle = x.CarManufacturer.Title,
                         CarModelID = x.CarModelID,
                         CarModelTitle = x.CarModel.Title,
                         CarYearTitle = x.CarYear.Year,
                         CarYearID = x.CarYearID,
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         Phone = x.Phone,
                         Email = x.Email,
                         Price = x.Price,
                         IsDone = x.IsDone,
                         IsRead = x.IsRead,
                         RequestDate = x.RequestDate
                     }).FirstOrDefault();
            if (a.IsRead == false)
            {
                SetAsRead(id);
            }
            return a;
        }

        public void SetAsDone(int id)
        {
            var a = db.Audit.FirstOrDefault(x => x.ID == id);
            a.IsDone = true;
            db.SaveChanges();
        }

        public void SetAsRead(int id)
        {
            var a = db.Audit.FirstOrDefault(x => x.ID == id);
            a.IsRead = true;
            db.SaveChanges();
        }

        public int GetUnReadCount()
        {
            return db.Audit.Count(x => x.IsRead == false);
        }

        public int GetUnDoneCount()
        {
            return db.Audit.Count(x => x.IsDone == false);
        }

        public int AllRequestCount()
        {
            return db.Audit.Count();
        }
    }
}
