﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using INTIME.Configuration.Dto;

namespace INTIME.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<List<ThemeSettingsDto>> GetUiManagementSettings();

        Task UpdateUiManagementSettings(ThemeSettingsDto settings);

        Task UpdateDefaultUiManagementSettings(ThemeSettingsDto settings);

        Task UseSystemDefaultSettings();

        Task ChangeDarkModeOfCurrentTheme(bool isDarkModeActive);
    }
}
