using System;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;
using BICT.Payetakht.Helper;

namespace BICT.Payetakht.Data.Repository
{
    public class AuditTempRepository : BaseRepository
    {
        public int Create(AuditViewModel auditTemp)
        {
            var cmydr = new CarModelYearDetailRepository();
            var item = new AuditTemp()
            {
                CarManufactureID = auditTemp.CarManufactureID,
                CarDetailID = auditTemp.CarDetailID,
                CarYearID = auditTemp.CarYearID,
                CarModelID = auditTemp.CarModelID,
                RequestDate = PersianDateTime.Parse(auditTemp.RequestDatePersian).ToDateTime(),
                FirstName = auditTemp.FirstName,
                LastName = auditTemp.LastName,
                Phone = auditTemp.Phone,
                Price = cmydr.GetPrice(auditTemp.CarModelID, auditTemp.CarYearID, auditTemp.CarDetailID),
                Email = auditTemp.Email,
            };
            db.AuditTemp.Add(item);
            db.SaveChanges();
            return item.ID;
        }
        public void Edit (int ID,long refid,string Authority)
        {
            var list = db.AuditTemp.Find(ID);

            list.PaymentDate = DateTime.Now;
            list.ReferID = refid;
            list.Authority = Authority;
            db.SaveChanges();
        }


        public AuditViewModel GetItem(int id)
        {
           return db.AuditTemp.Where(x => x.ID == id)
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
                         RequestDate = x.RequestDate
                     }).FirstOrDefault();
        }
    }
}
