using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ktpm_backend_master.Models
{
    [Table("learningcontentfolder")]
    public class LearningContentFolderTable : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("folderName")]
        public string FolderName { get; set; } = string.Empty;

        [Column("courseId")]
        public Guid CourseId { get; set; }
    }
}