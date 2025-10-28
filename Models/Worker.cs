using System.ComponentModel.DataAnnotations;

namespace WaterComplaintSystem.Models
{
    public class Worker
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        public int WardId { get; set; }
        public Ward? Ward { get; set; }

        public ICollection<Complaint>? Complaints { get; set; }
    }
}
