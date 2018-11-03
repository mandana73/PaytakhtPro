using System;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
    public class AuditTemp
    {
        [Key]
        public int ID { get; set; }

        public int CarManufactureID { get; set; }
        public int CarModelID { get; set; }
        public int CarYearID { get; set; }
        public int CarDetailID { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        public DateTime RequestDate { get; set; }

        public int Price { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual CarYear CarYear { get; set; }
        public virtual CarDetail CarDetail { get; set; }
    }
}
