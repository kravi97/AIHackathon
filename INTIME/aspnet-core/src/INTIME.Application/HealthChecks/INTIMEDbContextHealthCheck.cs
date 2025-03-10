﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using INTIME.EntityFrameworkCore;

namespace INTIME.HealthChecks
{
    public class INTIMEDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public INTIMEDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("INTIMEDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("INTIMEDbContext could not connect to database"));
        }
    }
}
