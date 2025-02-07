using System.Collections.Generic;
using Abp;
using INTIME.Chat.Dto;
using INTIME.Dto;

namespace INTIME.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
