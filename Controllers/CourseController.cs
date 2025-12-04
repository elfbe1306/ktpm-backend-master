using ktpm_backend_master.Services.Course;
using Microsoft.AspNetCore.Mvc;

namespace ktpm_backend_master.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCourse([FromRoute] string id)
        {
            var response = await _courseService.GetAllCourse(id);
            return Ok(response);
        }
    }
}