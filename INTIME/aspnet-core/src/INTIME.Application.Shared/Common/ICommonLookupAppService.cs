using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using INTIME.Common.Dto;
using INTIME.Editions.Dto;

namespace INTIME.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<FindUsersOutputDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}