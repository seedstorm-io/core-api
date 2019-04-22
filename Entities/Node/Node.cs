using System;
using System.ComponentModel.DataAnnotations;

namespace SeedStorm.Core.Entities.Node
{
    public class Node
    {
        [Key]
        public Guid Id { get; set; }
        public string CommonName { get; set; }
        public int Owner { get; set; }
        public string Template { get; set; }
        public string State { get; set; }
    }
}
