using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContentFolder;
using ktpm_backend_master.Repositories.LearningContentFolder;

namespace ktpm_backend_master.Services.LearningContentFolder
{
    public class LearningContentFolderService : ILearningContentFolderService
    {
        private readonly ILearningContentFolderRepository _learningContentFolderRepository;

        public LearningContentFolderService(ILearningContentFolderRepository learningContentFolderRepository)
        {
            _learningContentFolderRepository = learningContentFolderRepository;
        }

        public async Task<Result<LearningContentFolderItem[]>> GetAllLearningContentFolder(string courseId)
        {
            var folderResponse = await _learningContentFolderRepository.GetAllLearningContentFolder(Guid.Parse(courseId));

            if (!folderResponse.Success) return Result<LearningContentFolderItem[]>.Fail(folderResponse.Error);

            var folders = folderResponse.Data!;

            foreach (var folder in folders)
            {
                var contentResponse = await _learningContentFolderRepository.GetLearningContentsByFolderId(Guid.Parse(folder.Id));

                folder.Contents = contentResponse.Success ? contentResponse.Data! : [];
            }

            return Result<LearningContentFolderItem[]>.Ok(folders);
        }
    }
}