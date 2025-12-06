namespace ktpm_backend_master.DTO.LearningContentFolder
{
    public class LearningContentItem
    {
        public string Id { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string TypeContent { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class LearningContentFolderItem
    {
        public string Id { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;

        public LearningContentItem[] Contents { get; set; } = [];
    }
}