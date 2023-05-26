using System.ComponentModel.DataAnnotations;

namespace ProductCRUD_RepoPattern.Model
{
    public class BaseEntity
    {
        [Timestamp]
        public DateTime CreatedAt;
        [Timestamp]
        public DateTime? UpdatedAt;
        public bool IsDeleted;
    }
}
