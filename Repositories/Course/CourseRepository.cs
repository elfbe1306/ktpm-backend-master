using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Course;
using ktpm_backend_master.Models;

namespace ktpm_backend_master.Repositories.Course
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SupabaseClientService _supabaseService;

        public CourseRepository(SupabaseClientService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        public async Task<Result<CourseItem[]>> GetAllCourse(Guid userId)
        {
            var response = await _supabaseService.GetClient().From<CourseTable>().Where(c => c.TeachBy == userId).Get();

            var courses = response.Models.Select(c => new CourseItem
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Class = c.Class,
                CreatedAt = c.CreatedAt
            }).ToArray();

            return Result<CourseItem[]>.Ok(courses);
        }
    }
}