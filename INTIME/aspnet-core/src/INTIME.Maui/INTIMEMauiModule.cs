using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using INTIME.ApiClient;
using INTIME.Maui.Core;

namespace INTIME.Maui
{
    [DependsOn(typeof(INTIMEClientModule), typeof(AbpAutoMapperModule))]
    public class INTIMEMauiModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.ReplaceService<IApplicationContext, MauiApplicationContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(INTIMEMauiModule).GetAssembly());
        }
    }
}