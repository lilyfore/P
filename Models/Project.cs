namespace P.Models
{
    public class Project
    {
        public int Id { get; set; }                     // Unique ID for routing/details
        public string Title { get; set; } = string.Empty;  // Project title
        public string Description { get; set; } = string.Empty;  // Description of the project
        public string ImageUrl { get; set; } = string.Empty;     // Image path or URL
        public string GitHubLink { get; set; } = string.Empty;   // Link to the repo
    }
}
