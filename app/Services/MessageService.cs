using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Services
{
    using Repositories;
    using Models.Entities;
    using Models.ViewModels;

    public class MessageService : IMessageService
    {
        #region Dependencies

        private readonly IMessageRepository _msgRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        #endregion Dependencies

        #region Ctor

        public MessageService(
            IMessageRepository messageRepo,
            IRepository<User> userRepo,
            IMapper mapper,
            ILogger<MessageService> logger
        )
        {
            _msgRepository = messageRepo;
            _userRepository = userRepo;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion Ctor

        #region IMessageService

        public void Add(MessageView message)
        {
            try
            {
                var messageEntity = _mapper.Map<Message>(message);
                var users = _userRepository.GetItemList();
                messageEntity.User = users.First();
                messageEntity.Contact = users.Last();
                messageEntity.SendTime = DateTime.Now;

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
                var fromDt = DateTime.Now
                    .Subtract(TimeSpan.FromHours(hours));

                var msgEntities = _msgRepository?.GetItemList()
                    .Where(m => fromDt <= m.SendTime);

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
                    .Where(m => fromDt <= m.SendTime && m.SendTime <= endDt);

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
