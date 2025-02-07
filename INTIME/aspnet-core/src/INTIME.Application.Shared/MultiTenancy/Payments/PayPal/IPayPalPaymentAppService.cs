using System.Threading.Tasks;
using Abp.Application.Services;
using INTIME.MultiTenancy.Payments.PayPal.Dto;

namespace INTIME.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
