using app.Context;
using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Services
{
    public class MessageService : IMessageService
    {
        #region Dependencies

        private readonly IRepository<Message> _msgRepository;

        #endregion Dependencies

        #region Ctor

        public MessageService(IRepository<Message> messageRepo)
        {
            _msgRepository = messageRepo;            
        }

        #endregion Ctor

        #region IMessageService

        public void Add(Message message)
        {
            try
            {
                _msgRepository.Create(message);                
            }
            catch (Exception)
            {
                // TODO: use logger
                Console.WriteLine("Ошибка добавления сообщения в бд", message);                
            }
        }

        public IEnumerable<Message> GetMessages(int hours)
        {
            return _msgRepository?.GetItemList()
                .Where(m => m.CreateDateTime >= DateTime.Now.Subtract(TimeSpan.FromHours(hours)))
                .OrderBy(m => m.CreateDateTime);
        }

        #endregion IMessageService
    }
}
