using System;
using System.ComponentModel.DataAnnotations;

namespace SeedStorm.Core.Entities
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
