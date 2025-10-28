using System.ComponentModel.DataAnnotations;

namespace WaterComplaintSystem.Models
{
    // Practical 6: Model with nullable types
    public class Ward
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ward name is required")]
        [StringLength(100, ErrorMessage = "Ward name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Area is required")]
        [StringLength(200)]
        public string Area { get; set; } = string.Empty;

        public string? Description { get; set; } // Nullable type demonstration

        // Navigation property
        public ICollection<Complaint>? Complaints { get; set; }
        public ICollection<Worker>? Workers { get; set; }
    }
}
