using System.Collections.Generic;

namespace Project.DataProvider.Entities
{
    public class Service : BaseEntity<long>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
