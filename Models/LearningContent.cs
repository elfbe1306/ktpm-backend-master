using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ktpm_backend_master.Models
{
    [Table("learningcontent")]
    public class LearningContentTable : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("topic")]
        public string Topic { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("url")]
        public string Url { get; set; } = string.Empty;

        [Column("createdAt")]
        public string CreatedAt { get; set; } = string.Empty;

        [Column("typeContent")]
        public string TypeContent { get; set; } = string.Empty;

        [Column("learningContentFolderId")]
        public Guid LearningContentFolderId { get; set; }
    }
}