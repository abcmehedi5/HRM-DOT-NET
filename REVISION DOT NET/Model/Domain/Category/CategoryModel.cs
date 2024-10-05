using REVISION_DOT_NET.Model.Domain.Jobs;
using System.ComponentModel.DataAnnotations;

namespace REVISION_DOT_NET.Model.Domain.Category
{
    public class CategoryModel
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        public string categoryName { get; set; } = string.Empty;
        [Required]
        public string slug { get; set; }= string.Empty;
        [Required]
        public DateTime createdAt { get; set; }
        [Required]
        public DateTime updateAt { get; set; }

        // Navigation property for the job this job belongs to
        public ICollection<JobModel> Jobs { get; set; } = new List<JobModel>();
    }
}
