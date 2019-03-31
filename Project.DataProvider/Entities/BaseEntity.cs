using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DataProvider.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
    }
}
