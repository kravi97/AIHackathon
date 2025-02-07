using System.Threading.Tasks;
using INTIME.Authorization.Users;

namespace INTIME.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
