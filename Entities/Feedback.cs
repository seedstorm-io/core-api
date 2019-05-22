using System;
using System.ComponentModel.DataAnnotations;

namespace SeedStorm.Core.Entities
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Content { get; set; }
        public string RemoteIp { get; set; }
    }
}
