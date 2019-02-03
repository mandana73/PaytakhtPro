using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
    public class Inspection
    {
        [Key]
        public int ID { get; set; }

        public int AuditID { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string ColorType { get; set; }

        public int GearBoxNumner { get; set; }

        [StringLength(50)]
        public string GearBoxType { get; set; }

        public int EngineVolume { get; set; }
        public int CylinderNumber { get; set; }
        public int Usage { get; set; }

        [StringLength(50)]
        public string BodyType { get; set; }

        [StringLength(50)]
        public string FuelType { get; set; }

        [StringLength(50)]
        public string Roof { get; set; }

        [StringLength(50)]
        public string Trunk { get; set; }

        [StringLength(50)]
        public string Hood { get; set; }

        [StringLength(50)]
        public string DoorRightFront { get; set; }

        [StringLength(50)]
        public string DoorLeftFront { get; set; }

        [StringLength(50)]
        public string DoorRightRear { get; set; }

        [StringLength(50)]
        public string DoorLeftRear { get; set; }

        [StringLength(50)]
        public string PillarRightFront { get; set; }

        [StringLength(50)]
        public string PillarLeftFront { get; set; }

        [StringLength(50)]
        public string PillarRightRear { get; set; }

        [StringLength(50)]
        public string PillarLeftRear { get; set; }

        [StringLength(50)]
        public string FenderRightFront { get; set; }

        [StringLength(50)]
        public string FenderLeftFront { get; set; }

        [StringLength(50)]
        public string FenderRightRear { get; set; }

        [StringLength(50)]
        public string FenderLeftRear { get; set; }

        [StringLength(50)]
        public string PedalRight { get; set; }

        [StringLength(50)]
        public string PedalLeft { get; set; }

        [StringLength(50)]
        public string ChassisFront { get; set; }

        [StringLength(50)]
        public string ChassisRear { get; set; }

        public int TireRightFront { get; set; }

        public int TireLeftFront { get; set; }

        public int TireRightRear { get; set; }

        public int TireLeftRear { get; set; }

        public int TireSpare { get; set; }

        public virtual Audit Audit { get; set; }

        [StringLength(255)]
        public string DefaultPicture { get; set; }
    }
}
