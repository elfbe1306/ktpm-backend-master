using ktpm_backend_master.Common;
using ktpm_backend_master.DTO.Quiz;

namespace ktpm_backend_master.Repositories.Quiz
{
    public interface IQuizRepository
    {
        Task<Result<QuizFolder[]>> GetQuizFolderByFolderId(Guid folderId);
        Task<Result<QuizMultipleChoice[]>> GetQuizMultipleChoiceByQuizId(Guid quizId);
        Task<Result<QuizSubmit[]>> GetQuizSubmitByQuizId(Guid quizId);
        Task<Result<UpdateQuizMultipleChoiceRequest>> UpdateQuizMultipleChoice(Guid quizId, UpdateQuizMultipleChoiceRequest request);
        Task<Result<UpdateQuizSubmitChoiceRequest>> UpdateQuizSubmit(Guid quizId, UpdateQuizSubmitChoiceRequest request);
    }
}