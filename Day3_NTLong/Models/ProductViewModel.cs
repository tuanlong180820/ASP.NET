namespace Day3_NTLong.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        // Foreign key to Category
        public string CategoryName { get; set; }
        // Navigation property to Category
        
    }
}
