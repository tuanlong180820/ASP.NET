using System.ComponentModel.DataAnnotations;

namespace Day3_NTLong.Models
{
    public class category
    {
        [Required(ErrorMessage ="Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên danh mục phải từ 2 đến 100 kí tự")]
        public string Name { get; set; } = string.Empty;
        // Navigation property to Category
        public List<Product>? Products { get; set; }

    }
}
