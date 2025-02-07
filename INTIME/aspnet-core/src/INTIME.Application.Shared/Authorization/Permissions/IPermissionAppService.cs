using Abp.Application.Services;
using Abp.Application.Services.Dto;
using INTIME.Authorization.Permissions.Dto;

namespace INTIME.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
