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

        public async Task<Result<LearningContentItem>> CreateLearningContentWithoutFile(LearningContentTable content)
        {
            var response = await _supabaseService.GetClient().From<LearningContentTable>().Insert(content, new Supabase.Postgrest.QueryOptions { Returning = Supabase.Postgrest.QueryOptions.ReturnType.Representation });
            return Result<LearningContentItem>.Ok(new LearningContentItem
            {
                Id = response.Models.FirstOrDefault()?.Id.ToString() ?? "",
                Topic = response.Models.FirstOrDefault()?.Topic ?? "",
                Description = response.Models.FirstOrDefault()?.Description ?? "",
                TypeContent = response.Models.FirstOrDefault()?.TypeContent ?? "",
                Url = response.Models.FirstOrDefault()?.Url ?? "",
                CreatedAt = response.Models.FirstOrDefault()?.CreatedAt ?? ""
            });
        }

        public async Task<string> InsertFile(string learningContentId, IFormFile file)
        {
            var fileName = $"{learningContentId}/{file.FileName}";

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            await _supabaseService.GetClient().Storage.From("learningContent").Upload(fileBytes, fileName);
            var publicUrl = _supabaseService.GetClient().Storage.From("learningContent").GetPublicUrl(fileName);

            return publicUrl;
        }

        public async Task<Result<LearningContentItem>> UpdateLearningContentFileUrl(Guid learningContentId, string publicUrl)
        {
            var response = await _supabaseService.GetClient().From<LearningContentTable>().Where(l => l.Id == learningContentId).Single();

            if (response == null) return Result<LearningContentItem>.Fail("Fail to get learning content");
            response.Url = publicUrl;
            await response.Update<LearningContentTable>();

            return Result<LearningContentItem>.Ok( new LearningContentItem
            {
                Id = response.Id.ToString(),
                Topic = response.Topic,
                Description = response.Description,
                TypeContent = response.TypeContent,
                Url = response.Url,
                CreatedAt = response.CreatedAt
            });
        }
    }
}