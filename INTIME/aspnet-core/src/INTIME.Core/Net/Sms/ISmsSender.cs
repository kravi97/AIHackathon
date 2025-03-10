using System.Threading.Tasks;

namespace INTIME.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}