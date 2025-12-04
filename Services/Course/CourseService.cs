using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Course;
using ktpm_backend_master.Repositories.Course;

namespace ktpm_backend_master.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Result<CourseItem[]>> GetAllCourse(string id)
        {
            var response = await _courseRepository.GetAllCourse(Guid.Parse(id));
            return response;
        }
    }
}