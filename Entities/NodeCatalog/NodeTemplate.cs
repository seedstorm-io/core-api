using SeedStorm.Core.Entities.Node;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeedStorm.Core.Entities.NodeCatalog
{
    public class NodeTemplate
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Icon { get; set; }
        public string Poster { get; set; }
        public NodeType Type { get; set; }
        public Consensus Consensus { get; set; }
        public DateTime AddTime { get; set; }
        public int Priority { get; set; }
        public float HourlyCost { get; set; }
    }
}
