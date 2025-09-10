using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ManagedProperty:Property
    {
       
            public string AgentId { get; set; } = string.Empty; 
            public DateTime ManagedSince { get; set; }
            public decimal CommissionRate { get; set; }
            public DateTime? LeaseStartDate { get; set; }
            public DateTime? LeaseEndDate { get; set; }
            public string? CurrentTenantId { get; set; }
            public DateTime? LastInspectionDate { get; set; }
            public DateTime? NextInspectionDate { get; set; }
        }

}
