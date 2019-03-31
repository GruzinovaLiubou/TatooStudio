using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DataProvider.Entities
{
    public class BaseEntity<TKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }
    }
}
