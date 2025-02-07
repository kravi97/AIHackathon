using System.Collections.Generic;
using INTIME.Authorization.Users.Dto;
using INTIME.Dto;

namespace INTIME.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos, List<string> selectedColumns);
    }
}