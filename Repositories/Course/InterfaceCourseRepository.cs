using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Course;

namespace ktpm_backend_master.Repositories.Course
{
    public interface ICourseRepository
    {
        Task<Result<CourseItem[]>> GetAllCourse(Guid userId);
    }
}