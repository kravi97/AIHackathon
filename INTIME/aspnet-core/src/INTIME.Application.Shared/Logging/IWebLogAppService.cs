using Abp.Application.Services;
using INTIME.Dto;
using INTIME.Logging.Dto;

namespace INTIME.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
