using System.ComponentModel.DataAnnotations;

namespace CRUDProductApp_API.Models
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
