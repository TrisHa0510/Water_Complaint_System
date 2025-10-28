namespace WaterComplaintSystem.Extensions
{
    // Practical 7: Extension method demonstration
    public static class StringExtensions
    {
        // Extension method to get status badge color
        public static string GetStatusBadgeClass(this string status)
        {
            return status switch
            {
                "Pending" => "badge bg-warning text-dark",
                "InProgress" => "badge bg-info text-white",
                "Resolved" => "badge bg-success text-white",
                "Rejected" => "badge bg-danger text-white",
                _ => "badge bg-secondary text-white"
            };
        }

        // Extension method to get priority badge color
        public static string GetPriorityBadgeClass(this string priority)
        {
            return priority switch
            {
                "Low" => "badge bg-secondary",
                "Medium" => "badge bg-primary",
                "High" => "badge bg-warning text-dark",
                "Critical" => "badge bg-danger",
                _ => "badge bg-secondary"
            };
        }
    }
}
