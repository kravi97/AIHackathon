﻿using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using INTIME.MultiTenancy.Accounting.Dto;

namespace INTIME.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
