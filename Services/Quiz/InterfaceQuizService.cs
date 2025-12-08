using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Quiz;

namespace ktpm_backend_master.Services.Quiz
{
    public interface IQuizService
    {
        Task<Result<UpdateQuizMultipleChoiceRequest>> UpdateQuizMultipleChoice(string quizId, UpdateQuizMultipleChoiceRequest request);
        Task<Result<UpdateQuizSubmitChoiceRequest>> UpdateQuizSubmit(string quizId, UpdateQuizSubmitChoiceRequest request);
    }
}