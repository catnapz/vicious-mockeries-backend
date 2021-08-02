using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class MockeryCategory
    {
        public int MockeryId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Mockery Mockery { get; set; }
    }
}
