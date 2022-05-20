namespace EurisTest.Models
{
    public class CatalogProduct
    {
        public int CatalogProductId { get; set; }
        public int CatalogId { get; set; }
        public int ProductId { get; set; }

        public Catalog Catalog { get; set; }
        public Product Product { get; set; }
    }
}
