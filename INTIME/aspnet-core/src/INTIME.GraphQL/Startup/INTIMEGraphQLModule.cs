using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace INTIME.Startup
{
    [DependsOn(typeof(INTIMECoreModule))]
    public class INTIMEGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(INTIMEGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}