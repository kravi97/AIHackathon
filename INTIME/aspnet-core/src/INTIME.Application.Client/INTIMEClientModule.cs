using Abp.Modules;
using Abp.Reflection.Extensions;

namespace INTIME
{
    public class INTIMEClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(INTIMEClientModule).GetAssembly());
        }
    }
}
