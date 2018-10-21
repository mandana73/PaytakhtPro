namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarYear
    {
        public CarYear()
        {
            CarModelYearDetails = new HashSet<CarModelYearDetail>();
            Audits = new HashSet<Audit>();
        }

        [Key]
        public int ID { get; set; }

        public int CarModelID { get; set; }

        public int Year { get; set; }

        public virtual CarModel CarModel { get; set; }

        public ICollection<CarModelYearDetail> CarModelYearDetails { get; set; }
        public ICollection<Audit> Audits { get; set; }
    }
}
