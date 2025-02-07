using System.Collections.Generic;
using Abp.Dependency;
using INTIME.Dto;

namespace INTIME.DataImporting.Excel;

public interface IExcelInvalidEntityExporter<TEntityDto> : ITransientDependency
{
    FileDto ExportToFile(List<TEntityDto> entities);
}