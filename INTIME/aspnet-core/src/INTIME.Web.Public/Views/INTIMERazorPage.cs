using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace INTIME.Web.Public.Views
{
    public abstract class INTIMERazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected INTIMERazorPage()
        {
            LocalizationSourceName = INTIMEConsts.LocalizationSourceName;
        }
    }
}
