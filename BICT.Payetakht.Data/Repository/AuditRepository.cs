using System;
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
                Authority = audit.Authority,
                PaymentTypeID = audit.PaymentTypeID,
                IsDone = false,
                IsRead = false
            };
            db.Audits.Add(item);
            db.SaveChanges();
        }

        public IList<AuditViewModel> GetList()
        {
            return db.Audits
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

        public InspectionViewModel GetInspection(int id)
        {
            var item = db.Audits.Where(x => x.ID == id).Select(x => new InspectionViewModel
            {
                CarManufactureTitle = x.CarManufacturer.Title,
                CarDetailTitle = x.CarDetail.Title,
                CarYearTitle = x.CarYear.Year,
                CarModelTitle = x.CarModel.Title
            }).FirstOrDefault();

            var ins = db.Inspections.FirstOrDefault(x => x.AuditID == id);
            if (item != null && ins != null)
            {
                item.Description = ins.Description;
                item.Color = ins.Color;
                item.ColorType = ins.ColorType;
                item.GearBoxNumner = ins.GearBoxNumner;
                item.GearBoxType = ins.GearBoxType;
                item.Usage = ins.Usage;
                item.EngineVolume = ins.EngineVolume;
                item.CylinderNumber = ins.CylinderNumber;
                item.FuelType = ins.FuelType;
                item.Roof = ins.Roof;
                item.Trunk = ins.Trunk;
                item.Hood = ins.Hood;
                item.DoorRightFront = ins.DoorRightFront;
                item.DoorLeftFront = ins.DoorLeftFront;
                item.DoorRightRear = ins.DoorRightRear;
                item.DoorLeftRear = ins.DoorLeftRear;
                item.PillarRightFront = ins.PillarRightFront;
                item.PillarLeftFront = ins.PillarLeftFront;
                item.PillarRightRear = ins.PillarRightRear;
                item.PillarLeftRear = ins.PillarLeftRear;
                item.FenderRightFront = ins.FenderRightFront;
                item.FenderLeftFront = ins.FenderLeftFront;
                item.FenderRightRear = ins.FenderRightRear;
                item.FenderLeftRear = ins.FenderLeftRear;
                item.PedalRight = ins.PedalRight;
                item.PedalLeft = ins.PedalLeft;
                item.ChassisFront = ins.ChassisFront;
                item.ChassisRear = ins.ChassisRear;
                item.TireRightFront = ins.TireRightFront;
                item.TireLeftFront = ins.TireLeftFront;
                item.TireRightRear = ins.TireRightRear;
                item.TireLeftRear = ins.TireLeftRear;
                item.TireSpare = ins.TireSpare;
                item.BodyType = ins.BodyType;
            }

            return item;
        }

        public IList<InspectionViewModel> GetInspectionList(int pageNum)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * 10;
            return db.Inspections
                 .OrderByDescending(x => x.ID)
                 .Skip(skip)
                 .Take(10)
                 .Select(x => new InspectionViewModel
                 {
                     AuditID = x.AuditID,
                     Description = x.Description,
                     Color = x.Color,
                     ColorType = x.ColorType,
                     GearBoxNumner = x.GearBoxNumner,
                     GearBoxType = x.GearBoxType,
                     Usage = x.Usage,
                     EngineVolume = x.EngineVolume,
                     CylinderNumber = x.CylinderNumber,
                     FuelType = x.FuelType,
                     Roof = x.Roof,
                     Trunk = x.Trunk,
                     Hood = x.Hood,
                     DoorRightFront = x.DoorRightFront,
                     DoorLeftFront = x.DoorLeftFront,
                     DoorRightRear = x.DoorRightRear,
                     DoorLeftRear = x.DoorLeftRear,
                     PillarRightFront = x.PillarRightFront,
                     PillarLeftFront = x.PillarLeftFront,
                     PillarRightRear = x.PillarRightRear,
                     PillarLeftRear = x.PillarLeftRear,
                     FenderRightFront = x.FenderRightFront,
                     FenderLeftFront = x.FenderLeftFront,
                     FenderRightRear = x.FenderRightRear,
                     FenderLeftRear = x.FenderLeftRear,
                     PedalRight = x.PedalRight,
                     PedalLeft = x.PedalLeft,
                     ChassisFront = x.ChassisFront,
                     ChassisRear = x.ChassisRear,
                     TireRightFront = x.TireRightFront,
                     TireLeftFront = x.TireLeftFront,
                     TireRightRear = x.TireRightRear,
                     TireLeftRear = x.TireLeftRear,
                     TireSpare = x.TireSpare,
                     BodyType = x.BodyType,
                     CarDetailTitle = x.Audit.CarDetail.Title,
                     CarManufactureTitle = x.Audit.CarManufacturer.Title,
                     CarModelTitle = x.Audit.CarModel.Title,
                     CarYearTitle = x.Audit.CarYear.Year
                 }).ToList();
        }


        public void InsertInspection(int id, InspectionViewModel model)
        {
            SetAsDone(id);
            var ins = db.Inspections.FirstOrDefault(x => x.AuditID == id);
            if (ins == null)
            {
                ins = new Inspection
                {
                    AuditID = id,
                    Description = model.Description,
                    Color = model.Color,
                    ColorType = model.ColorType,
                    GearBoxNumner = model.GearBoxNumner,
                    GearBoxType = model.GearBoxType,
                    Usage = model.Usage,
                    EngineVolume = model.EngineVolume,
                    CylinderNumber = model.CylinderNumber,
                    FuelType = model.FuelType,
                    Roof = model.Roof,
                    Trunk = model.Trunk,
                    Hood = model.Hood,
                    DoorRightFront = model.DoorRightFront,
                    DoorLeftFront = model.DoorLeftFront,
                    DoorRightRear = model.DoorRightRear,
                    DoorLeftRear = model.DoorLeftRear,
                    PillarRightFront = model.PillarRightFront,
                    PillarLeftFront = model.PillarLeftFront,
                    PillarRightRear = model.PillarRightRear,
                    PillarLeftRear = model.PillarLeftRear,
                    FenderRightFront = model.FenderRightFront,
                    FenderLeftFront = model.FenderLeftFront,
                    FenderRightRear = model.FenderRightRear,
                    FenderLeftRear = model.FenderLeftRear,
                    PedalRight = model.PedalRight,
                    PedalLeft = model.PedalLeft,
                    ChassisFront = model.ChassisFront,
                    ChassisRear = model.ChassisRear,
                    TireRightFront = model.TireRightFront,
                    TireLeftFront = model.TireLeftFront,
                    TireRightRear = model.TireRightRear,
                    TireLeftRear = model.TireLeftRear,
                    TireSpare = model.TireSpare,
                    BodyType = model.BodyType
                };
                db.Inspections.Add(ins);
            }
            else
            {
                ins.Description = model.Description;
                ins.Color = model.Color;
                ins.ColorType = model.ColorType;
                ins.GearBoxNumner = model.GearBoxNumner;
                ins.GearBoxType = model.GearBoxType;
                ins.Usage = model.Usage;
                ins.EngineVolume = model.EngineVolume;
                ins.CylinderNumber = model.CylinderNumber;
                ins.FuelType = model.FuelType;
                ins.Roof = model.Roof;
                ins.Trunk = model.Trunk;
                ins.Hood = model.Hood;
                ins.DoorRightFront = model.DoorRightFront;
                ins.DoorLeftFront = model.DoorLeftFront;
                ins.DoorRightRear = model.DoorRightRear;
                ins.DoorLeftRear = model.DoorLeftRear;
                ins.PillarRightFront = model.PillarRightFront;
                ins.PillarLeftFront = model.PillarLeftFront;
                ins.PillarRightRear = model.PillarRightRear;
                ins.PillarLeftRear = model.PillarLeftRear;
                ins.FenderRightFront = model.FenderRightFront;
                ins.FenderLeftFront = model.FenderLeftFront;
                ins.FenderRightRear = model.FenderRightRear;
                ins.FenderLeftRear = model.FenderLeftRear;
                ins.PedalRight = model.PedalRight;
                ins.PedalLeft = model.PedalLeft;
                ins.ChassisFront = model.ChassisFront;
                ins.ChassisRear = model.ChassisRear;
                ins.TireRightFront = model.TireRightFront;
                ins.TireLeftFront = model.TireLeftFront;
                ins.TireRightRear = model.TireRightRear;
                ins.TireLeftRear = model.TireLeftRear;
                ins.TireSpare = model.TireSpare;
                ins.BodyType = model.BodyType;
            }
            db.SaveChanges();
        }

        public IList<AuditViewModel> GetPagedList(int pageNum, int? read, int? done)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * 10;
            var query = db.Audits.AsQueryable();
            if (read != null)
            {
                var readBool = Convert.ToBoolean(read);
                query = query.Where(x => x.IsRead == readBool);
            }
            if (done != null)
            {
                var doneBool = Convert.ToBoolean(done);
                query = query.Where(x => x.IsDone == doneBool);
            }
            return query
                .OrderByDescending(x => x.ID)
                .Skip(skip)
                .Take(10)
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
                 })
                .ToList();
        }

        public AuditViewModel Getitem(int id)
        {
            var a = db.Audits.Where(x => x.ID == id)
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
            var a = db.Audits.FirstOrDefault(x => x.ID == id);
            if (a.IsDone != true)
            {
                a.IsDone = true;
            }
            db.SaveChanges();
        }

        public void SetAsRead(int id)
        {
            var a = db.Audits.FirstOrDefault(x => x.ID == id);
            if (a.IsRead != true)
            {
                a.IsRead = true;
            }
            db.SaveChanges();
        }

        public int GetUnReadCount()
        {
            return db.Audits.Count(x => x.IsRead == false);
        }

        public int GetUnDoneCount()
        {
            return db.Audits.Count(x => x.IsDone == false);
        }

        public int AllRequestCount()
        {
            return db.Audits.Count();
        }
    }
}
