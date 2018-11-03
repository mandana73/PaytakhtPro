
namespace BICT.Payetakht.Payment
{
    public class ZarinPal
    {
        public static int ZarinpalPayment(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL, out string Authority)
        {
            try
            {
                ZarinPalService.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPalService.PaymentGatewayImplementationServicePortTypeClient();
                var Status = zp.PaymentRequest(MerchantID, Amount, Description, Email, Mobile, CallbackURL, out Authority);
                return Status;
            }
            catch
            {
                Authority = string.Empty;
                return -1000;
            }
        }
        public static int ZarinpalPaymentVerification(string MerchantID, string Authority, int Amount)
        {
            try
            {
                ZarinPalService.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPalService.PaymentGatewayImplementationServicePortTypeClient();

                var Status = zp.PaymentVerification(MerchantID, Authority, Amount, out long RefID);
                return Status;
            }
            catch
            {
                Authority = string.Empty;
                return -1000;
            }
        }

    }
}
