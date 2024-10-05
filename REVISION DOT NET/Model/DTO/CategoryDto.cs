using System.ComponentModel.DataAnnotations;

namespace REVISION_DOT_NET.Model.DTO
{
    public class CategoryDto
    {

        [Key]
        public int categoryId { get; set; }
        [Required]
        public string categoryName { get; set; } = string.Empty;
        [Required]
        public string slug { get; set; } = string.Empty;
        [Required]
        public DateTime createdAt { get; set; }
        [Required]
        public DateTime updateAt { get; set; }
    }
}
