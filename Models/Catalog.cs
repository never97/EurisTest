using System.ComponentModel.DataAnnotations;

namespace EurisTest.Models
{
    public class Catalog
    {
        [Key]
        public int CatalogId { get; set; }
        [Required]
        public string? Code { get; set; }
        public string? Description { get; set; }
        public List<Product>? products { get; set; }
        //public ICollection<CatalogProduct> CatalogProducts { get; set; }

    }
}