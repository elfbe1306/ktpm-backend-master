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
            var response = await _learningContentFolderRepository.GetAllLearningContentFolder(Guid.Parse(courseId));
            return response;
        }
    }
}