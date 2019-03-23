using SeedStorm.CoreApi.Entities.Node;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeedStorm.CoreApi.Entities.NodeCatalog
{
    public class NodeTemplate
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Icon { get; set; }
        public string Poster { get; set; }
        public NodeType Type { get; set; }
        public Consensus Consensus { get; set; }
        public DateTime AddTime { get; set; }
        public int Priority { get; set; }
        public ICollection<Node.Node> Nodes { get; set; }
    }
}
