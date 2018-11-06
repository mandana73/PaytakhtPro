namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarModel
    {
        public CarModel()
        {
            CarYears = new HashSet<CarYear>();
            CarDetails = new HashSet<CarDetail>();
            CarModelYearDetails = new HashSet<CarModelYearDetail>();
            Audits = new HashSet<Audit>();
            AuditTemps = new HashSet<AuditTemp>();
        }

        [Key]
        public int ID { get; set; }

        public int CarManufacturerID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }

        public ICollection<CarYear> CarYears { get; set; }
        public ICollection<CarDetail> CarDetails { get; set; }
        public ICollection<CarModelYearDetail> CarModelYearDetails { get; set; }
        public ICollection<Audit> Audits { get; set; }
        public ICollection<AuditTemp> AuditTemps { get; set; }
    }
}
