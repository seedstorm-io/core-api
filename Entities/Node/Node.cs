using SeedStorm.Core.Entities.NodeCatalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeedStorm.Core.Entities.Node
{
    public class Node
    {
        [Key]
        public Guid Id { get; set; }
        public string CommonName { get; set; }
        public int Owner { get; set; }
        public string Template { get; set; }
        public NodeState State { get; set; }
    }
}
