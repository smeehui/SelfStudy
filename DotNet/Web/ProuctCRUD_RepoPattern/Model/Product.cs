using ProductCRUD_RepoPattern.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProuctCRUD_RepoPattern.Model
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
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("price")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Column("Category_Id")]
        public Category? Category { get; set; }
    }
}
