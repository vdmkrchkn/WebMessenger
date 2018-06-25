using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models.Entities
{
    /// <summary>
    /// DAO модель сообщения 
    /// </summary>
    [Table("Messages")]
    public class MessageEntity : BaseEntity
    {        
        [Required]
		public string Text { get; set; }

        public string UserName { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; }
    }
}
