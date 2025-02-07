using System.Threading.Tasks;
using Abp.Application.Services;
using INTIME.MultiTenancy.Payments.Dto;
using INTIME.MultiTenancy.Payments.Stripe.Dto;

namespace INTIME.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();
        
        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}