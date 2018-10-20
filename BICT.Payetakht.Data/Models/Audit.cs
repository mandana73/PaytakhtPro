namespace BICT.Payetakht.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Audit
    {
        [Key]
        public int ID { get; set; }

        public int CarManufactureID { get; set; }
        public int CarModelID { get; set; }
        public int CarYearID { get; set; }
        public int CarDetailID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual CarYear CarYear { get; set; }
        public virtual CarDetail CarDetail { get; set; }

        public int Price { get; set; }
    }
}
