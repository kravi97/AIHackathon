using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using INTIME.Dto;

namespace INTIME.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
