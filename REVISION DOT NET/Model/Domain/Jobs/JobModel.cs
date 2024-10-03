using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REVISION_DOT_NET.Model.Domain.Jobs
{
    public class JobModel
    {
        [Key]
        public int Job_id { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string title { get; set; } = string.Empty;

        [Required] 
        public string description { get; set; } = string.Empty;

        [ForeignKey("Category")]  // Foreign key to Category entity
        public int category_id { get; set; }

        [ForeignKey("PostedBy")]  // Foreign key to the user/entity who posted
        public int posted_by_id { get; set; }

        [ForeignKey("Location")]  // Foreign key to Location entity
        public int location_id { get; set; }

        [ForeignKey("Company")]  // Foreign key to Company entity
        public int company_id { get; set; }

        public string thumbnail { get; set; } = string.Empty;
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
