using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ktpm_backend_master.Models
{
    [Table("user")]
    public class NewUser : BaseModel
    {
        [PrimaryKey("id", false)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("createdAt")]
        public string CreatedAt { get; set; } = string.Empty;
    }
}