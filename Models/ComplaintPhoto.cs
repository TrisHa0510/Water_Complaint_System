using System.ComponentModel.DataAnnotations;

namespace WaterComplaintSystem.Models
{
    public class ComplaintPhoto
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        public int ComplaintId { get; set; }
        public Complaint? Complaint { get; set; }
    }
}
