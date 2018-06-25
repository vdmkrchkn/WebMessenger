using app.Context;
using app.Models.Entities;
using app.Models.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        #endregion Dependencies

        #region Ctor

        public MessageService(IMapper mapper, ILogger<MessageService> logger, IRepository<MessageEntity> messageRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _msgRepository = messageRepo;            
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
            catch(AutoMapperConfigurationException e)
            {
                _logger.LogError(e, "Cannot map transfer object to access object", message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot add new message to database", message);                            
            }
        }

        public IEnumerable<MessageView> GetMessages(int hours)
        {
            try
            {
                var fromDt = DateTime.Now.Subtract(TimeSpan.FromHours(hours));

                var msgEntities = _msgRepository?.GetItemList()
                    .Where(m => fromDt <= m.CreateDateTime);

                return _mapper.Map<IEnumerable<MessageView>>(msgEntities);
            }
            catch (Exception)
            {                
                _logger.LogError("Cannot get messages from database for hours", hours);                 
                return null;
            }            
        }

        public IEnumerable<MessageView> GetMessages(string beginDate, string endDate)
        {
            try
            {                
                var fromDt = string.IsNullOrEmpty(beginDate) ? DateTime.MinValue
                    : DateTime.Parse(beginDate);                
                var endDt = string.IsNullOrEmpty(endDate) ? DateTime.Now
                    : DateTime.Parse(endDate);

                var msgEntities = _msgRepository?.GetItemList()
                    .Where(m => fromDt <= m.CreateDateTime && m.CreateDateTime <= endDt);                

                return _mapper.Map<IEnumerable<MessageView>>(msgEntities);
            }
            catch(FormatException)
            {
                _logger.LogError("Cannot transform datetime periods", beginDate, endDate);                
                return null;
            }
            catch (Exception)
            {                
                _logger.LogError("Cannot get messages from database for datetime period", beginDate, endDate);                
                return null;
            }
        }

        #endregion IMessageService
    }
}
