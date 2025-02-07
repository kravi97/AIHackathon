using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using INTIME.Configure;
using INTIME.Startup;
using INTIME.Test.Base;

namespace INTIME.GraphQL.Tests
{
    [DependsOn(
        typeof(INTIMEGraphQLModule),
        typeof(INTIMETestBaseModule))]
    public class INTIMEGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(INTIMEGraphQLTestModule).GetAssembly());
        }
    }
}