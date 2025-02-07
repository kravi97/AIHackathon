using Abp.AspNetCore.Mvc.Views;

namespace INTIME.Web.Views
{
    public abstract class INTIMERazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected INTIMERazorPage()
        {
            LocalizationSourceName = INTIMEConsts.LocalizationSourceName;
        }
    }
}
