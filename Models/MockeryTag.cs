using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class MockeryTag
    {
        public int MockeryId { get; set; }
        public int TagId { get; set; }

        public virtual Mockery Mockery { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
