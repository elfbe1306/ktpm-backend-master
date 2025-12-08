using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Quiz;
using ktpm_backend_master.Repositories.Quiz;

namespace ktpm_backend_master.Services.Quiz
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Result<UpdateQuizMultipleChoiceRequest>> UpdateQuizMultipleChoice(string quizId, UpdateQuizMultipleChoiceRequest request)
        {
            var response = await _quizRepository.UpdateQuizMultipleChoice(Guid.Parse(quizId), request);
            return response;
        }

        public async Task<Result<UpdateQuizSubmitChoiceRequest>> UpdateQuizSubmit(string quizId, UpdateQuizSubmitChoiceRequest request)
        {
            var response = await _quizRepository.UpdateQuizSubmit(Guid.Parse(quizId), request);
            return response;
        }
    }
}