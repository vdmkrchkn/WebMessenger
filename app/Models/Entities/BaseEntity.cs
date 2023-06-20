using System;
using System.ComponentModel.DataAnnotations;

namespace app.Models.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
