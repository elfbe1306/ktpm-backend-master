using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.LearningContent;
using ktpm_backend_master.Models;

namespace ktpm_backend_master.Repositories.LearningContent
{
    public class LearningContentRepository : ILearningContentRepository
    {
        private readonly SupabaseClientService _supabaseService;

        public LearningContentRepository(SupabaseClientService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        public async Task<Result<LearningContentItem[]>> GetLearningContentsByFolderId(Guid folderId)
        {
            var response = await _supabaseService.GetClient().From<LearningContentTable>().Where(c => c.LearningContentFolderId == folderId).Get();

            var contents = response.Models.Select(c => new LearningContentItem
            {
                Id = c.Id.ToString(),
                Topic = c.Topic,
                Description = c.Description,
                TypeContent = c.TypeContent,
                CreatedAt = c.CreatedAt.ToString(),
                Url = c.Url
            }).ToArray();

            return Result<LearningContentItem[]>.Ok(contents);
        }

        public async Task<Result<LearningContentItem>> CreateLearningContentWithoutFile(LearningContentTable learningContentOject)
        {
            var response = await _supabaseService.GetClient().From<LearningContentTable>().Insert(learningContentOject, new Supabase.Postgrest.QueryOptions { Returning = Supabase.Postgrest.QueryOptions.ReturnType.Representation });
            return Result<LearningContentItem>.Ok( new LearningContentItem
            {
                Id = response.Models.FirstOrDefault()?.Id.ToString() ?? ""
            });
        }
    }
}