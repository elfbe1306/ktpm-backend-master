namespace ktpm_backend_master.DTO.Quiz
{
    public class QuizMultipleChoice
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int QuestionNumber { get; set; }
        public string AnswerA { get; set; } = string.Empty;
        public string AnswerB { get; set; } = string.Empty;
        public string AnswerC { get; set; } = string.Empty;
        public string AnswerD { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }

    public class QuizSubmit
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int QuestionNumber { get; set; }
        public string Url { get; set; } = string.Empty;
    }

    public class QuizFolder
    {
        public string Id { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Minutes { get; set; }
        public string TypeQuiz { get; set; } = string.Empty;
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public QuizMultipleChoice[]? QuizMultipleChoices { get; set; } = [];
        public QuizSubmit[]? QuizSubmits { get; set; } = [];
    }

    public class UpdateQuizMultipleChoiceRequest
    {
        public string Text { get; set; } = string.Empty;
        public int QuestionNumber { get; set; }
        public string AnswerA { get; set; } = string.Empty;
        public string AnswerB { get; set; } = string.Empty;
        public string AnswerC { get; set; } = string.Empty;
        public string AnswerD { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }

    public class UpdateQuizSubmitChoiceRequest
    {
        public string Text { get; set; } = string.Empty;
        public int QuestionNumber { get; set; }
    }
}