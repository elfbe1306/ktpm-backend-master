using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Quiz;
using ktpm_backend_master.Models;

namespace ktpm_backend_master.Repositories.Quiz
{
    public class QuizRepository : IQuizRepository
    {
        private SupabaseClientService _supabaseService;

        public QuizRepository(SupabaseClientService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        public async Task<Result<QuizFolder[]>> GetQuizFolderByFolderId(Guid folderId)
        {
            var response = await _supabaseService.GetClient().From<QuizFolderTable>().Where(q => q.LearningContentFolderId == folderId).Get();

            var quizzes = response.Models.Select(q => new QuizFolder
            {
                Id = q.Id.ToString(),
                CloseTime = q.CloseTime,
                OpenTime = q.OpenTime,
                CreatedAt = q.CreatedAt,
                Minutes = q.Minutes,
                Topic = q.Name,
                Description = q.Description,
                TypeQuiz = q.TypeQuiz
            }).ToArray();

            return Result<QuizFolder[]>.Ok(quizzes);
        }

        public async Task<Result<QuizMultipleChoice[]>> GetQuizMultipleChoiceByQuizId(Guid quizId)
        {
            var response = await _supabaseService.GetClient().From<QuizMultipleChoiceTable>().Where(q => q.QuizFolderId == quizId).Get();

            var quiz = response.Models.Select(q => new QuizMultipleChoice
            {
                Id = q.Id.ToString(),
                AnswerA = q.AnswerA,
                AnswerB = q.AnswerB,
                AnswerC = q.AnswerC,
                AnswerD = q.AnswerD,
                Answer = q.Answer,
                Text = q.Text,
                QuestionNumber = q.QuestionNumber
            }).ToArray();

            return Result<QuizMultipleChoice[]>.Ok(quiz);
        }

        public async Task<Result<QuizSubmit[]>> GetQuizSubmitByQuizId(Guid quizId)
        {
            var response = await _supabaseService.GetClient().From<QuizSubmitTable>().Where(q => q.QuizFolderId == quizId).Get();

            var quiz = response.Models.Select(q => new QuizSubmit
            {
                Id = q.Id.ToString(),
                Text = q.Text,
                QuestionNumber = q.QuestionNumber,
                Url = q.Url
            }).ToArray();

            return Result<QuizSubmit[]>.Ok(quiz);
        }

        public async Task<Result<UpdateQuizMultipleChoiceRequest>> UpdateQuizMultipleChoice(Guid quizId, UpdateQuizMultipleChoiceRequest request)
        {
            var response = await _supabaseService.GetClient().From<QuizMultipleChoiceTable>().Where(q => q.Id == quizId).Single();

            if (response == null) return Result<UpdateQuizMultipleChoiceRequest>.Fail("There is no multiple choice question");

            response.QuestionNumber = request.QuestionNumber;
            response.Text = request.Text;
            response.Answer = request.Answer;
            response.AnswerA = request.AnswerA;
            response.AnswerB = request.AnswerB;
            response.AnswerC = request.AnswerC;
            response.AnswerD = request.AnswerD;

            await response.Update<QuizMultipleChoiceTable>();

            return Result<UpdateQuizMultipleChoiceRequest>.Ok(request);
        }

        public async Task<Result<UpdateQuizSubmitChoiceRequest>> UpdateQuizSubmit(Guid quizId, UpdateQuizSubmitChoiceRequest request)
        {
            var response = await _supabaseService.GetClient().From<QuizSubmitTable>().Where(q => q.Id == quizId).Single();

            if (response == null) return Result<UpdateQuizSubmitChoiceRequest>.Fail("There is no multiple choice question");

            response.Text = request.Text;
            response.QuestionNumber = request.QuestionNumber;

            await response.Update<QuizSubmitTable>();
            return Result<UpdateQuizSubmitChoiceRequest>.Ok(request);
        }
    }
}