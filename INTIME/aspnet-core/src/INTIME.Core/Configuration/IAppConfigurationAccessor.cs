using Microsoft.Extensions.Configuration;

namespace INTIME.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
