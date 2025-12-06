using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContentFolder;
using ktpm_backend_master.Models;

namespace ktpm_backend_master.Repositories.LearningContentFolder
{
    public class LearningContentFolderRepository : ILearningContentFolderRepository
    {
        private readonly SupabaseClientService _supabaseService;

        public LearningContentFolderRepository(SupabaseClientService supabaseClient)
        {
            _supabaseService = supabaseClient;
        }

        public async Task<Result<LearningContentFolderItem[]>> GetAllLearningContentFolder(Guid courseId)
        {
            var response = await _supabaseService.GetClient().From<LearningContentFolderTable>().Where(l => l.CourseId == courseId).Get();

            var courses = response.Models.Select(c => new LearningContentFolderItem
            {
                Id = c.Id.ToString(),
                FolderName = c.FolderName,
            }).ToArray();

            return Result<LearningContentFolderItem[]>.Ok(courses);
        }

        public async Task<Result<LearningContentItem[]>> GetLearningContentsByFolderId(Guid folderId)
        {
            var response = await _supabaseService.GetClient().From<LearningContentTable>().Where(c => c.LearningContentFolderId == folderId).Get();

            var contents = response.Models.Select(c => new LearningContentItem
            {
                Id = c.Id.ToString(),
                Topic = c.Topic,
                TypeContent = c.TypeContent,
                CreatedAt = c.CreatedAt.ToString(),
                Url = c.Url
            }).ToArray();

            return Result<LearningContentItem[]>.Ok(contents);
        }
    }
}