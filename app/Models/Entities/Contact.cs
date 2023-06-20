using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models.Entities
{
    public class Contact : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public User Owner { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
