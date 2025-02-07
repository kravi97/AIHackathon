using System.Threading.Tasks;
using INTIME.Sessions.Dto;

namespace INTIME.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
