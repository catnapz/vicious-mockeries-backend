using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Tag
    {
        public Tag()
        {
            MockeryTags = new HashSet<MockeryTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MockeryTag> MockeryTags { get; set; }
    }
}
