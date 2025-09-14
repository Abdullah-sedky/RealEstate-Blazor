using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public ICollection<Property> Properties { get; set; } = new List<Property>(); 
    }
}
// Identity library creates IdentityUser model with main user login info,
// but to add more fields, I created ApplicationUser that implements IdentityUser, with extra fields.
