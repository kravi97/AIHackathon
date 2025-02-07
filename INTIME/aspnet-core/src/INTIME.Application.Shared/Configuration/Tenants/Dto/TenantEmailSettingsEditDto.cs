using Abp.Auditing;
using INTIME.Configuration.Dto;

namespace INTIME.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}