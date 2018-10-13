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
        }

        [Key]
        public int ID { get; set; }

        public int CarManufacturerID { get; set; }

        public int CarDetailID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }
        public ICollection<CarYear> CarYears { get; set; }
        public ICollection<CarDetail> CarDetails { get; set; }
    }
}
