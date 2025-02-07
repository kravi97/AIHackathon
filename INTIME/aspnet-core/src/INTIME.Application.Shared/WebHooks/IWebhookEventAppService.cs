using System.Threading.Tasks;
using Abp.Webhooks;

namespace INTIME.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
