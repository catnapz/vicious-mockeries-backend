using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Category
    {
        public Category()
        {
            MockeryCategories = new HashSet<MockeryCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MockeryCategory> MockeryCategories { get; set; }
    }
}
