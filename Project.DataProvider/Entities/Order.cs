using System;

namespace Project.DataProvider.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Time { get; set; }
        public virtual Employee Employee { get; set; }
        // TODO: Add User field and add config to it
        public virtual Service Services { get; set; }
    }
}
