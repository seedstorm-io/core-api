using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedStorm.CoreApi.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegisterDatetime { get; set; }
        public bool IsAllowed { get; set; }
    }
}
