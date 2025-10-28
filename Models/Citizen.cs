using System.ComponentModel.DataAnnotations;

namespace WaterComplaintSystem.Models
{
    public class Citizen
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Address { get; set; } = string.Empty;

        public ICollection<Complaint>? Complaints { get; set; }
    }
}
