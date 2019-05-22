using System;

namespace SeedStorm.Core.Entities
{
    public class Announce
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ActionButton { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
