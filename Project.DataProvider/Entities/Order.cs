using System;
using System.Collections.Generic;

namespace Project.DataProvider.Entities
{
    public class Order : BaseEntity<long>
    {
        public DateTime Time { get; set; }
        public virtual Employee Employee { get; set; }        
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
