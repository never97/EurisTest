using System.ComponentModel.DataAnnotations;

namespace EurisTest.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(10)]
        public string? Code { get; set; }
        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
        public List<Catalog>? catalogs { get; set; }
        //public ICollection<CatalogProduct> CatalogProducts { get; set; }
    }
}

