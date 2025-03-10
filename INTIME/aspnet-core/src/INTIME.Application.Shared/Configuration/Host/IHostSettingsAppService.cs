﻿using System.Threading.Tasks;
using Abp.Application.Services;
using INTIME.Configuration.Host.Dto;

namespace INTIME.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
