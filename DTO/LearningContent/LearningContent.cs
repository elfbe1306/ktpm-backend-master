namespace ktpm_backend_master.DTO.LearningContent
{
    public class LearningContentItem
    {
        public string Id { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TypeContent { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class CreateLearningContentRequest
    {
        public string Topic { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string TypeContent { get; set; } = string.Empty;
        public string? Url { get; set; }
        public IFormFile? File { get; set; }
    }

    public class DeleteLearningContentRequest
    {
        public string TypeContent { get; set; } = string.Empty;
    }
}