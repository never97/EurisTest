namespace EurisTest.Models.ViewModels
{
    public class CatalogIndexData
    {
        public IEnumerable<Catalog> Catalogs { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CatalogProduct> CatalogProducts { get; set; }
    }
}
