using app.Models.ViewModels;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace app.Controllers
{
    [Route("chat/[controller]")]
    public class MessagesController : Controller
    {
        #region Dependencies

        private readonly IMessageService _msgService;
        private readonly ILogger _logger;        

        #endregion Dependencies

        #region Ctor

        public MessagesController(ILogger<MessagesController> logger, IMessageService msgService)
        {
            _logger = logger;
            _msgService = msgService;                        
        }

        #endregion Ctor

        // GET messages
        [HttpGet("{hours?}")]
        public IEnumerable<MessageView> Get(int? hours)
        {
            if (hours.HasValue)
                return _msgService?.GetMessages(hours.Value);
            else
            {                
                var from = Request.Query.FirstOrDefault(p => p.Key == "from").Value;                
                var to = Request.Query.FirstOrDefault(p => p.Key == "to").Value;                    
                
                return _msgService?.GetMessages(from, to);
            }
        }        
        
        // POST messages
        [HttpPost]
        public IActionResult Add([FromBody]MessageView newMessage)
        {
			if (newMessage == null)
			{
                _logger.LogError("Trying to add an empty message");
				return BadRequest();
			}

			_msgService.Add(newMessage);

            _logger.LogInformation("New message was added", newMessage);
			return Ok();
        }        
    }
}
