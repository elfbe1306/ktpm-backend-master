using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ktpm_backend_master.Models
{
    [Table("quizSubmit")]
    public class QuizSubmitTable : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("text")]
        public string Text { get; set; } = string.Empty;

        [Column("url")]
        public string Url { get; set; } = string.Empty;

        [Column("questionNumber")]
        public int QuestionNumber { get; set; }
        
        [Column("quizFolderId")]
        public Guid QuizFolderId { get; set; }
    }
}