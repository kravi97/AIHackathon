using INTIME.Auditing.Dto;
using INTIME.Dto;
using INTIME.EntityChanges.Dto;
using System.Collections.Generic;

namespace INTIME.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
