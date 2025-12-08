using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ktpm_backend_master.Models
{
    [Table("quizfolder")]
    public class QuizFolderTable : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("minutes")]
        public int Minutes { get; set; }

        [Column("typeQuiz")]
        public string TypeQuiz { get; set; } = string.Empty;

        [Column("openTime")]
        public string OpenTime { get; set; } = string.Empty;

        [Column("closeTime")]
        public string CloseTime { get; set; } = string.Empty;

        [Column("createdAt")]
        public string CreatedAt { get; set; } = string.Empty;
        
        [Column("learningContentFolderId")]
        public Guid LearningContentFolderId { get; set; }
    }
}