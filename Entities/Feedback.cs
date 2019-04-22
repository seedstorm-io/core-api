using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeedStorm.Core.Entities
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public string RemoteIp { get; set; }
    }
}
