using Abp.Modules;
using Abp.Reflection.Extensions;

namespace INTIME
{
    public class INTIMECoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(INTIMECoreSharedModule).GetAssembly());
        }
    }
}