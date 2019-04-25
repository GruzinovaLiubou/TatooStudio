using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Project.DataProvider.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string PhoneNumber { get; set; }
        public override string Email { get; set; }
        public override string UserName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
