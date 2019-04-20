using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedStorm.Core.Entities
{
    public class Announce
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ActionButton { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
