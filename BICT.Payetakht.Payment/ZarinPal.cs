
using System;

namespace BICT.Payetakht.Payment
{
    public class ZarinPal
    {
        public static int ZarinpalPayment(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL, out string Authority)
        {
            Authority = string.Empty;
            try
            {
                ZarinPalService.PaymentGatewayImplementationServicePortTypeClient client = new ZarinPalService.PaymentGatewayImplementationServicePortTypeClient();
                var Status = client.PaymentRequest(MerchantID, Amount, Description, Email, Mobile, CallbackURL, out Authority);
                return Status;
            }
            catch ()
            {
                return -1000;
            }
        }
        public static int ZarinpalPaymentVerification(string MerchantID, string Authority, int Amount, out long RefID)
        {

            ZarinPalService.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPalService.PaymentGatewayImplementationServicePortTypeClient();
            var Status = zp.PaymentVerification(MerchantID, Authority, Amount, out RefID);
            return Status;


        }
        public static string GetMessage(int status)
        {
            switch (status)
            {
                case -1:
                    return "اطلاعات ارسال شده  ناقص است.";
                case -2:
                    return "IP و یا مرچنت کد پذیرنده صحیح نیست.";
                case -3:
                    return "با توجه به محدودیت های شاپرک امکان پرداخت با رقم درخواست شده میسر نمی باشد.";
                case -4:
                    return "سطح تایید پذیرنده پایین تر از سطح نقره ای است.";
                case -11:
                    return "درخواست مورد نظر یافت نشد.";
                case -12:
                    return "امکان ویرایش درخواست میسر نمی باشد.";
                case -21:
                    return "هیچ نوع عملیات مالی برای این تراکنش یافت نشد.";
                case -22:
                    return "تراکنش ناموفق می باشد.";
                case -33:
                    return "رقم تراکنش با رقم پرداخت شده مطابقت ندارد.";
                case -34:
                    return "سقف تقسیم تراکنش از لحاظ تعداد یا رقم عبور نموده است.";
                case -40:
                    return "اجازه دسترسی به متد مربوطه وجود ندارد.";
                case -41:
                    return "اطلاعات ارسال شده مربوط به AdditionalData غیر معتبر می باشد.";
                case -42:
                    return "مدت زمان معتبر طول عمر شناسه پرداخت باید بین 30 دقیقه تا 45 روز می باشد.";
                case -54:
                    return "درخواست مورد نظر آرشیو شده است.";
                case 100:
                    return "عملیات با موفقیت انجام گردیده است.";
                case 101:
                    return "عملیات پرداخت موفق بوده و قبلاً PaymentVerification تراکنش انجام شده است.";
                default:
                    return "کد تعریف نشده.";
            }
        }

    }
}
