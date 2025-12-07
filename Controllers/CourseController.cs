using ktpm_backend_master.DTO.LearningContent;
using ktpm_backend_master.DTO.LearningContentFolder;
using ktpm_backend_master.Services.Course;
using ktpm_backend_master.Services.LearningContent;
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
        private readonly ILearningContentService _learningContentService;

        public CourseController(ICourseService courseService, ILearningContentFolderService learningContentFolderService, ILearningContentService learningContentService)
        {
            _courseService = courseService;
            _learningContentFolderService = learningContentFolderService;
            _learningContentService = learningContentService;
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

        [HttpPost("folder/{id}/create")]
        public async Task<IActionResult> CreateLearningContentFolder([FromRoute] string id, [FromBody] LearningContentCreateRequest request)
        {
            var response = await _learningContentFolderService.CreateLearningContentFolder(id, request.FolderName);
            return Ok(response);
        }

        [HttpPost("content/create/{folderId}")]
        public async Task<IActionResult> CreateLearningContent([FromRoute] string folderId, [FromForm] CreateLearningContentRequest request)
        {
            var response = await _learningContentService.CreateLearningContent(folderId, request);
            return Ok(response);
        }
    }
}