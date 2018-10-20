using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

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
                Date = audit.Date,
                FirstName = audit.FirstName,
                LastName = audit.LastName,
                Phone = audit.Phone,
                Price = cmydr.GetPrice(audit.CarModelID, audit.CarYearID, audit.CarDetailID),
                Email = audit.Email,
            };
            db.Audit.Add(item);
            db.SaveChanges();
        }
    }
}
