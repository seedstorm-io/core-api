using System;
using System.ComponentModel.DataAnnotations;

namespace SeedStorm.Core.Entities
{
    public class Cluster
    {
        [Key]
        public Guid Id { get; set; }
        public string Endpoint { get; set; }
        public string Credentials { get; set; }
        public string Certificate { get; set; }
        public bool Used { get; set; } = true;
    }
}
