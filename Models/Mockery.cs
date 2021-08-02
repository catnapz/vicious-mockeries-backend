using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Mockery
    {
        public Mockery()
        {
            MockeryCategories = new HashSet<MockeryCategory>();
            MockeryTags = new HashSet<MockeryTag>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }

        public virtual ICollection<MockeryCategory> MockeryCategories { get; set; }
        public virtual ICollection<MockeryTag> MockeryTags { get; set; }
    }
}
