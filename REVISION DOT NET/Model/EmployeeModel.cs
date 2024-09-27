using System.ComponentModel.DataAnnotations.Schema;

namespace REVISION_DOT_NET.Model
{
    public class EmployeeModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public int EmployeeId { get; set; } = int.MaxValue;

        public string Department { get; set; } = string.Empty;

        public DateTime DateOfJoining { get; set; } = DateTime.MinValue;

        public string ContactNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; } = 0.0m;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        public bool IsActive { get; set; } = true;

        public string Role { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Supervisor { get; set; } = string.Empty;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public string EmploymentType { get; set; } = "Full-Time";

        public List<string> Skills { get; set; } = new List<string>();

        public string EmergencyContact { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;

        public string MaritalStatus { get; set; } = string.Empty;

        public ICollection<LeaveModel> Leaves { get; set; } = new List<LeaveModel>();
    }
}
