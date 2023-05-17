using System.ComponentModel.DataAnnotations;

namespace AEPortal.Common.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
