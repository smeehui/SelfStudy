using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDProductApp_API.Models
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("price")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public Guid Category_Id { get; set; }
        public Category Category { get; set; }
    }
}
