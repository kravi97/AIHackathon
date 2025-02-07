using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTIME.AI
{
    public class Project : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public string Name { get; set; }
        public int TenantId { get ; set ; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
