using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class DashboardViewModel
    {
        [Display(Name = "خوانده نشده")]
        public int AuditUnRead { get; set; }

        [Display(Name = "انجام نشده")]
        public int AuditUnDone { get; set; }

        [Display(Name = "تمامی درخواست ها")]
        public int AuditAllRequest { get; set; }

        [Display(Name = "تمامی سازنده ها")]
        public int CarManufactureCount { get; set; }

        [Display(Name = "تمامی مدل ها")]
        public int CarModelCount { get; set; }

        [Display(Name = "جزئیات")]
        public int CarDetailCount { get; set; }
    }
}
