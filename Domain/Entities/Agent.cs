using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Agent : ApplicationUser
    {
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

        public List<ManagedProperty> ManagedProperties { get; set; } = new();
        public List<Notification> Notifications { get; set; } = new();
    }
}
