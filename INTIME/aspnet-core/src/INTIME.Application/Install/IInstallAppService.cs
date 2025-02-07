using System.Threading.Tasks;
using Abp.Application.Services;
using INTIME.Install.Dto;

namespace INTIME.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}