using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContentFolder;

namespace ktpm_backend_master.Services.LearningContentFolder
{
    public interface ILearningContentFolderService
    {
        Task<Result<LearningContentFolderItem[]>> GetAllLearningContentFolder(string courseId);
        Task<Result<LearningContentFolderItem>> CreateLearningContentFolder(string courseId, string folderName);
        Task<Result<LearningContentFolderItem>> UpdateLearningContentFolder(string folderId, string folderName);
        Task<Result<string>> DeleteLearningContentFolder(string folderId);
    }
}