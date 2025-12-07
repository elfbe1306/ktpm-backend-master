using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContent;
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

        public async Task<Result<LearningContentFolderItem>> CreateLearningContentFolder(Guid courseId, string folderName)
        {

            var response = await _supabaseService.GetClient()
                .From<LearningContentFolderTable>()
                .Insert(new LearningContentFolderTable
                {
                    FolderName = folderName,
                    CourseId = courseId
                }, new Supabase.Postgrest.QueryOptions { Returning = Supabase.Postgrest.QueryOptions.ReturnType.Representation });

            return Result<LearningContentFolderItem>.Ok(new LearningContentFolderItem
            {
                Id = response.Models.FirstOrDefault()?.Id.ToString() ?? "",
                FolderName = response.Models.FirstOrDefault()?.FolderName ?? "",
            });
        }

        public async Task<Result<LearningContentFolderItem>> UpdateLearningContentFolder(Guid folderId, string folderName)
        {
            var response = await _supabaseService.GetClient().From<LearningContentFolderTable>().Where(l => l.Id == folderId).Single();

            if (response == null) return Result<LearningContentFolderItem>.Fail("Fail to get learning content folder");
            response.FolderName = folderName;

            await response.Update<LearningContentFolderTable>();

            return Result<LearningContentFolderItem>.Ok(new LearningContentFolderItem
            {
                Id = response.Id.ToString(),
                FolderName = response.FolderName
            });
        }

        public async Task<Result<string>> DeleteLearningContentFolder(Guid folderId)
        {
            await _supabaseService.GetClient().From<LearningContentFolderTable>().Where(l => l.Id == folderId).Delete();
            return Result<string>.Ok(folderId.ToString());
        }
    }
}