using System.ComponentModel.DataAnnotations;

namespace app.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
