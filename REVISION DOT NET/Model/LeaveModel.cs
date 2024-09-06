using System;
using System.ComponentModel.DataAnnotations;

namespace REVISION_DOT_NET.Model
{
    public class LeaveModel
    {
        [Key]
        public int LeaveId { get; set; }

        [Required]
        public string LeaveName { get; set; } = string.Empty;

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LeaveStatus { get; set; } = "Pending";

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateApplied { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(20)]
        public string LeaveType { get; set; } = "Full Day";

        public int? ApprovedBy { get; set; } // Nullable to handle unapproved cases

        [MaxLength(250)]
        public string Remarks { get; set; } = string.Empty;
    }
}
