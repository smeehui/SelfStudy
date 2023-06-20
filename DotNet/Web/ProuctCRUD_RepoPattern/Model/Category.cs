
using ProductCRUD_RepoPattern.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProuctCRUD_RepoPattern.Model
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
