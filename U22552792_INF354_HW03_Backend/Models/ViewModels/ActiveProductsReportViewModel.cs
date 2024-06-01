namespace U22552792_INF354_HW03_Backend.Models.ViewModels
{
    public class ActiveProductsReportViewModel
    {
        public class ActiveProductsReportDTO
        {
            public string Brand { get; set; }
            public List<ProductTypeWithProductsDTO> ProductTypes { get; set; }
        }

        public class ProductTypeWithProductsDTO
        {
            public string ProductType { get; set; }
            public List<ProductDTO> Products { get; set; }
        }

        public class ProductDTO
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Image { get; set; }
        }
    }
}
