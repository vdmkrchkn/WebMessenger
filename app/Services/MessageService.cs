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

        public MessageService(IRepository<MessageEntity> messageRepo, IMapper mapper, ILogger<MessageService> logger)
        {
            _msgRepository = messageRepo;
            _mapper = mapper;
            _logger = logger;
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

                _logger.LogInformation("New message=[{msg}] was added", messageEntity);
            }            
            catch(AutoMapperConfigurationException e)
            {
                _logger.LogError(e, "Cannot map transfer object [{msg}] to access object", message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot add new message={msg} to database", message);                            
            }
        }

        public IEnumerable<MessageView> GetMessages(int hours)
        {
            try
            {
                var fromDt = DateTime.Now.Subtract(TimeSpan.FromHours(hours));

                var msgEntities = _msgRepository?.GetItemList()
                    .Where(m => fromDt <= m.CreateDateTime);

                _logger.LogInformation("GetMessages returns {nMsg} messages", msgEntities.Count());

                return _mapper.Map<IEnumerable<MessageView>>(msgEntities);
            }
            catch (Exception e)
            {                
                _logger.LogError(e, "Cannot get messages from database for {h} hours", hours);                 
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

                _logger.LogInformation("GetMessages returns {nMsg} messages", msgEntities.Count());

                return _mapper.Map<IEnumerable<MessageView>>(msgEntities);
            }
            catch(FormatException fe)
            {
                _logger.LogError(fe, "Cannot transform {beginDate} or {endDate} to datetime value", beginDate, endDate);                
                return null;
            }
            catch (Exception e)
            {                
                _logger.LogError(e, "Cannot get messages from database from {beginDate} to {endDate}", beginDate, endDate);                
                return null;
            }
        }

        #endregion IMessageService
    }
}
