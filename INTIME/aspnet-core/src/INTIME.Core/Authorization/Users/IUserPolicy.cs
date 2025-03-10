﻿using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace INTIME.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
