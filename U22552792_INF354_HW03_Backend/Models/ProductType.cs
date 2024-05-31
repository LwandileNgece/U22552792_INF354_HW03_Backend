namespace U22552792_INF354_HW03_Backend.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; }
    }
}
