using System;
using System.ComponentModel.DataAnnotations;

namespace SeedStorm.Core.Entities.NodeCatalog
{
    public class NodeTemplate
    {
        [Key]
        public Guid Id { get; set; }
        public bool Listed { get; set; } = true;
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Icon { get; set; }
        public string Poster { get; set; }
        public string Version { get; set; }
        public string Type { get; set; }
        public string Consensus { get; set; }
        public DateTime AddTime { get; set; }
        public int Priority { get; set; }
        public float HourlyCost { get; set; }
    }
}
