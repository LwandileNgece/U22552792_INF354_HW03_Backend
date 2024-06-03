namespace U22552792_INF354_HW03_Backend.Models.ViewModels
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int ProductTypeId { get; set; }
        public IFormFile Image { get; set; }
    }
}
