using Microsoft.AspNetCore.Identity;
using System;

namespace SeedStorm.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string FullHash { get; set; }
        public DateTime RegisterDatetime { get; set; }
        public bool IsAllowed { get; set; }
    }
}
