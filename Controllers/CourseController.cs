using ktpm_backend_master.Services.Course;
using ktpm_backend_master.Services.LearningContentFolder;
using Microsoft.AspNetCore.Mvc;

namespace ktpm_backend_master.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILearningContentFolderService _learningContentFolderService;

        public CourseController(ICourseService courseService, ILearningContentFolderService learningContentFolderService)
        {
            _courseService = courseService;
            _learningContentFolderService = learningContentFolderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCourse([FromRoute] string id)
        {
            var response = await _courseService.GetAllCourse(id);
            return Ok(response);
        }

        [HttpGet("folder/{id}")]
        public async Task<IActionResult> GetAllLearningContentFolder([FromRoute] string id)
        {
            var response = await _learningContentFolderService.GetAllLearningContentFolder(id);
            return Ok(response);
        }
    }
}