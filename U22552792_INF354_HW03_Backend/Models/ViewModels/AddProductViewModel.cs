namespace U22552792_INF354_HW03_Backend.Models.ViewModels
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }
        public int BrandId { get; set; }
        public string Image { get; set; }
    }
}
