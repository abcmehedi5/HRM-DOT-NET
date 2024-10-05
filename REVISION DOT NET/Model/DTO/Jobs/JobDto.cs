using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace REVISION_DOT_NET.Model.DTO.Jobs
{
    public class JobDto
    {
        [Key]
        public int Job_id { get; set; }

        [Required]
        [MaxLength(100)]
        public string title { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        public int category_id { get; set; }

        public int posted_by_id { get; set; }

        public int location_id { get; set; }

        public int company_id { get; set; }

        public string thumbnail { get; set; } = string.Empty;
    }
}
