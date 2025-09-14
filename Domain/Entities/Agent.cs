using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
     public class Agent : ApplicationUser
    {
        public int AgentId { get; set; }
        public int YOE { get; set; }
        public int TotalDeals { get; set; }
        public int ClosedDeals { get; set; }
        public int LicenseNum { get; set; }
        public double Rating { get; set; }
        public string AgencyName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string OfficeAddress { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string LinkedinProf { get; set; } = string.Empty;
        public string FacebookProf { get; set; } = string.Empty;
        public string ProfilePicUrl { get; set; } = string.Empty;

        public List<ManagedProperty>? ManagedProperties;
        public List<Notification>? Notifications;
        public List<Task>? Tasks;

        public string UserId { get; set; } = null!; 
        public ApplicationUser User { get; set; } = null!; // Navigation property
    }
}
