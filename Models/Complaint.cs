using System.ComponentModel.DataAnnotations;

namespace WaterComplaintSystem.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Resolved, Rejected

        [Required]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High, Critical

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ResolvedDate { get; set; }

        [Required]
        public int CitizenId { get; set; }
        public Citizen? Citizen { get; set; }

        [Required]
        public int WardId { get; set; }
        public Ward? Ward { get; set; }

        public int? AssignedWorkerId { get; set; }
        public Worker? AssignedWorker { get; set; }

        public ICollection<ComplaintPhoto>? Photos { get; set; }
    }
}
