using System;
using System.ComponentModel.DataAnnotations;

namespace app.Models.Entities
{
    /// <summary>
    /// DAO модель сообщения 
    /// </summary>
    public class Message : BaseEntity
    {        
        [Required]
		public string Content { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid? ContactId { get; set; }
        public User Contact { get; set; }

        [Required]
        public DateTime SendTime { get; set; }

        public DateTime DeliveryTime { get; set; }

        public override string ToString() => 
            $"{UserId} send message {Content} to {ContactId} at {SendTime}";
    }
}
