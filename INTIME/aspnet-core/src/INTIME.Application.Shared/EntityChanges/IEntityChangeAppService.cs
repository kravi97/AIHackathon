using Abp.Application.Services;
using Abp.Application.Services.Dto;
using INTIME.EntityChanges.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace INTIME.EntityChanges
{
    public interface IEntityChangeAppService : IApplicationService
    {
        Task<ListResultDto<EntityAndPropertyChangeListDto>> GetEntityChangesByEntity(GetEntityChangesByEntityInput input);
    }
}
