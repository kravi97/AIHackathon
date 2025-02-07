using System.Threading.Tasks;
using Abp.Application.Services;
using INTIME.Sessions.Dto;

namespace INTIME.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
