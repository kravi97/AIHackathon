using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using INTIME.MultiTenancy.HostDashboard.Dto;

namespace INTIME.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}