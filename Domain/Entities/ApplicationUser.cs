using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Range(18, 120)]
        public int Age { get; set; }

        [Phone]
        public string? Number { get; set; }
        public UserRole Role { get; set; } 

        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
        public virtual Agent? AgentProfile { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

}
