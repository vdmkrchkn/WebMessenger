using app.Context;
using app.Models.Entities;
using app.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Services
{
    public class MessageService : IMessageService
    {
        #region Dependencies

        private readonly IRepository<MessageEntity> _msgRepository;
        private readonly IMapper _mapper;

        #endregion Dependencies

        #region Ctor

        public MessageService(IRepository<MessageEntity> messageRepo, IMapper mapper)
        {
            _msgRepository = messageRepo;
            _mapper = mapper;
        }

        #endregion Ctor

        #region IMessageService

        public void Add(MessageView message)
        {
            try
            {
                var messageEntity = _mapper.Map<MessageEntity>(message);
                messageEntity.CreateDateTime = DateTime.Now;

                _msgRepository.Create(messageEntity);                
            }
            catch (Exception)
            {
                // TODO: use logger
                Console.WriteLine("Ошибка добавления сообщения в бд", message);                
            }
        }

        public IEnumerable<MessageView> GetMessages(int hours)
        {
            try
            {
                var fromDt = DateTime.Now.Subtract(TimeSpan.FromHours(hours));

                var msgEntities = _msgRepository?.GetItemList()
                    .Where(m => fromDt <= m.CreateDateTime)
                    .OrderBy(m => m.CreateDateTime);

                return _mapper.Map<IEnumerable<MessageView>>(msgEntities);
            }
            catch (Exception)
            {
                // TODO: use logger
                Console.WriteLine($"Ошибка получения сообщений из бд за последние {hours} часов");
                return null;
            }            
        }

        public IEnumerable<MessageView> GetMessages(string beginDate, string endDate)
        {
            try
            {
                var fromDt = DateTime.Parse(beginDate);
                var endDt = DateTime.Parse(endDate);

                var msgEntities = _msgRepository?.GetItemList()
                    .Where(m => fromDt <= m.CreateDateTime && m.CreateDateTime <= endDt)
                    .OrderBy(m => m.CreateDateTime);                

                return _mapper.Map<IEnumerable<MessageView>>(msgEntities);
            }
            catch(FormatException)
            {
                Console.WriteLine("Ошибка преобразования входных временных данных", beginDate, endDate);
                return null;
            }
            catch (Exception)
            {
                // TODO: use logger
                Console.WriteLine($"Ошибка получения сообщений из бд за период с {beginDate} по {endDate}");
                return null;
            }
        }

        #endregion IMessageService
    }
}
