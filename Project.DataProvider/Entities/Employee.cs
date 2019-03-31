using System.Collections.Generic;

namespace Project.DataProvider.Entities
{
    public class Employee: BaseEntity
    {
        public string Name { get; set; }
        public double PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
