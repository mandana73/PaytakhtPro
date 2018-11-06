namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CarYear
    {
        public CarYear()
        {
            CarModelYearDetails = new HashSet<CarModelYearDetail>();
            Audits = new HashSet<Audit>();
            AuditTemps = new HashSet<AuditTemp>();
        }

        [Key]
        public int ID { get; set; }

        public int CarModelID { get; set; }

        public int Year { get; set; }

        public virtual CarModel CarModel { get; set; }

        public ICollection<CarModelYearDetail> CarModelYearDetails { get; set; }
        public ICollection<Audit> Audits { get; set; }
        public ICollection<AuditTemp> AuditTemps { get; set; }
    }
}
