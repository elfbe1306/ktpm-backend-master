using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ktpm_backend_master.Models
{
    [Table("quizMultipleChoice")]
    public class QuizMultipleChoiceTable : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("text")]
        public string Text { get; set; } = string.Empty;

        [Column("answerA")]
        public string AnswerA { get; set; } = string.Empty;

        [Column("answerB")]
        public string AnswerB { get; set; } = string.Empty;

        [Column("answerC")]
        public string AnswerC { get; set; } = string.Empty;

        [Column("answerD")]
        public string AnswerD { get; set; } = string.Empty;

        [Column("answer")]
        public string Answer { get; set; } = string.Empty;

        [Column("questionNumber")]
        public int QuestionNumber { get; set; }
        
        [Column("quizFolderId")]
        public Guid QuizFolderId { get; set; }
    }
}