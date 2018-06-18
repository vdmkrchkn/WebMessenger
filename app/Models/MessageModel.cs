using System;
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    /// <summary>
    /// Модель DTO сообщения 
    /// </summary>
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
		public string Text { get; set; }

        public string UserName { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; }
    }
}
