using ktpm_backend_master.DTO.LearningContent;
using ktpm_backend_master.DTO.LearningContentFolder;
using ktpm_backend_master.DTO.Quiz;
using ktpm_backend_master.Services.Course;
using ktpm_backend_master.Services.LearningContent;
using ktpm_backend_master.Services.LearningContentFolder;
using ktpm_backend_master.Services.Quiz;
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
        private readonly IQuizService _quizService;

        public CourseController(ICourseService courseService, ILearningContentFolderService learningContentFolderService, ILearningContentService learningContentService, IQuizService quizService)
        {
            _courseService = courseService;
            _learningContentFolderService = learningContentFolderService;
            _learningContentService = learningContentService;
            _quizService = quizService;
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

        [HttpPut("folder/{folderId}/update")]
        public async Task<IActionResult> UpdateLearningContentFolder([FromRoute] string folderId, [FromBody] LearningContentCreateRequest request)
        {
            var response = await _learningContentFolderService.UpdateLearningContentFolder(folderId, request.FolderName);
            return Ok(response);
        }

        [HttpDelete("folder/{folderId}/delete")]
        public async Task<IActionResult> DeleteLearningContentFolder([FromRoute] string folderId)
        {
            var response = await _learningContentFolderService.DeleteLearningContentFolder(folderId);
            return Ok(response);
        }

        [HttpPost("content/create/{folderId}")]
        public async Task<IActionResult> CreateLearningContent([FromRoute] string folderId, [FromForm] CreateLearningContentRequest request)
        {
            var response = await _learningContentService.CreateLearningContent(folderId, request);
            return Ok(response);
        }

        [HttpDelete("content/delete/{contentId}")]
        public async Task<IActionResult> DeleteLearningContent([FromRoute] string contentId, [FromBody] DeleteLearningContentRequest request)
        {
            var response = await _learningContentService.DeleteLearningContent(contentId, request.TypeContent);
            return Ok(response);
        }

        [HttpPut("quiz/multiplechoice/update/{quizId}")]
        public async Task<IActionResult> UpdateQuizMultipleChoice([FromRoute] string quizId, [FromBody] UpdateQuizMultipleChoiceRequest request)
        {
            var response = await _quizService.UpdateQuizMultipleChoice(quizId, request);
            return Ok(response);
        }

        [HttpPut("quiz/submit/update/{quizId}")]
        public async Task<IActionResult> UpdateQuizSubmit([FromRoute] string quizId, [FromBody] UpdateQuizSubmitChoiceRequest request)
        {
            var response = await _quizService.UpdateQuizSubmit(quizId, request);
            return Ok(response);
        }

        [HttpPost("quiz/create/{folderId}")]
        public async Task<IActionResult> CreateQuiz([FromRoute] string folderId, [FromBody] CreateQuizRequest request)
        {
            var response = await _quizService.CreateQuiz(folderId, request);
            return Ok(response);
        }
    }
}