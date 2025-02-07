using Abp.AspNetCore.Mvc.ViewComponents;

namespace INTIME.Web.Public.Views
{
    public abstract class INTIMEViewComponent : AbpViewComponent
    {
        protected INTIMEViewComponent()
        {
            LocalizationSourceName = INTIMEConsts.LocalizationSourceName;
        }
    }
}