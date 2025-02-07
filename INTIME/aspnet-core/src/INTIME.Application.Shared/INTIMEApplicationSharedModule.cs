using Abp.Modules;
using Abp.Reflection.Extensions;

namespace INTIME
{
    [DependsOn(typeof(INTIMECoreSharedModule))]
    public class INTIMEApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(INTIMEApplicationSharedModule).GetAssembly());
        }
    }
}