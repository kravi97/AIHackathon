using System.Threading.Tasks;
using Abp.Application.Services;
using INTIME.Configuration.Tenants.Dto;

namespace INTIME.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearDarkLogo();
        
        Task ClearDarkLogoMinimal();

        Task ClearLightLogo();
        
        Task ClearLightLogoMinimal();

        Task ClearCustomCss();
    }
}
