using ktpm_backend_master.DTO.LearningContent;

namespace ktpm_backend_master.DTO.LearningContentFolder
{
    public class LearningContentFolderItem
    {
        public string Id { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;

        public LearningContentItem[] Contents { get; set; } = [];
    }

    public class LearningContentCreateRequest {
        public string FolderName { get; set; } = string.Empty;
    }
}