using Abp.Domain.Services;

namespace INTIME
{
    public abstract class INTIMEDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected INTIMEDomainServiceBase()
        {
            LocalizationSourceName = INTIMEConsts.LocalizationSourceName;
        }
    }
}
