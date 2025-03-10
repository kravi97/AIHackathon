﻿using System.Threading.Tasks;
using Abp.Dependency;

namespace INTIME.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}