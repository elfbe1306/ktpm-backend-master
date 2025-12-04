using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Course;

namespace ktpm_backend_master.Services.Course
{
    public interface ICourseService
    {
        Task<Result<CourseItem[]>> GetAllCourse(string userId);
    }
}