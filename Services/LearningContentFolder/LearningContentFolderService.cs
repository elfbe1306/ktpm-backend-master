using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContentFolder;
using ktpm_backend_master.Repositories.LearningContent;
using ktpm_backend_master.Repositories.LearningContentFolder;

namespace ktpm_backend_master.Services.LearningContentFolder
{
    public class LearningContentFolderService : ILearningContentFolderService
    {
        private readonly ILearningContentFolderRepository _learningContentFolderRepository;
        private readonly ILearningContentRepository _learningContentRepository;

        public LearningContentFolderService(ILearningContentFolderRepository learningContentFolderRepository, ILearningContentRepository learningContentRepository)
        {
            _learningContentFolderRepository = learningContentFolderRepository;
            _learningContentRepository = learningContentRepository;
        }

        public async Task<Result<LearningContentFolderItem[]>> GetAllLearningContentFolder(string courseId)
        {
            var folderResponse = await _learningContentFolderRepository.GetAllLearningContentFolder(Guid.Parse(courseId));

            if (!folderResponse.Success) return Result<LearningContentFolderItem[]>.Fail(folderResponse.Error);

            var folders = folderResponse.Data!;

            foreach (var folder in folders)
            {
                var contentResponse = await _learningContentRepository.GetLearningContentsByFolderId(Guid.Parse(folder.Id));

                folder.Contents = contentResponse.Success ? contentResponse.Data! : [];
            }

            return Result<LearningContentFolderItem[]>.Ok(folders);
        }
    }
}