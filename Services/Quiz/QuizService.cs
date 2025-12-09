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

        public async Task<Result<QuizFolder>> CreateQuiz(string folderId, CreateQuizRequest request)
        {
            var quizFolderResponse = await _quizRepository.CreateQuizFolder(Guid.Parse(folderId), request);

            if (!quizFolderResponse.Success || quizFolderResponse.Data == null)
                return Result<QuizFolder>.Fail("Failed to create quiz folder.");

            var folder = quizFolderResponse.Data;
            var quizList1 = new List<QuizMultipleChoice>();
            var quizList2 = new List<QuizSubmit>();

            foreach (var quiz in request.QuizMultipleChoices)
            {
                var quizResponse = await _quizRepository.CreateQuizMultipleChoice(Guid.Parse(folder.Id), quiz);
                if (!quizResponse.Success || quizResponse.Data == null)
                    return Result<QuizFolder>.Fail("Failed to create a quiz item.");
                quizList1.Add(quizResponse.Data);
            }

            foreach (var quiz in request.QuizSubmits)
            {
                var quizResponse = await _quizRepository.CreateQuizSubmit(Guid.Parse(folder.Id), quiz);
                if (!quizResponse.Success || quizResponse.Data == null)
                    return Result<QuizFolder>.Fail("Failed to create a quiz item.");
                quizList2.Add(quizResponse.Data);
            }

            folder.QuizMultipleChoices = quizList1.ToArray();
            folder.QuizSubmits = quizList2.ToArray();

            return Result<QuizFolder>.Ok(folder);
        }
    }
}