using System;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class CarModelYearDetailViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "مدل را وارد نمایید")]
        public int CarModelID { get; set; }
        public String CarModelTitle { get; set; }

        [Required(ErrorMessage = "جزئیات را وارد نمایید")]
        public int CarDetailID { get; set; }
        public String CarDetailTitle { get; set; }


        [Required(ErrorMessage = "سال را وارد نمایید")]
        public int CarYearID { get; set; }
        public int CarYearTitle { get; set; }

        [Required(ErrorMessage = "قیمت را وارد نمایید")]
        public int Price { get; set; }
    }
}
