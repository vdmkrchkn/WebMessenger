using app.Models.ViewModels;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace app.Controllers
{
    [Route("chat/[controller]")]
    public class MessagesController : Controller
    {
        #region Dependencies

        private readonly IMessageService _msgService;

        #endregion Dependencies

        #region Ctor

        public MessagesController(IMessageService msgService)
        {
            _msgService = msgService;                        
        }

        #endregion Ctor

        // GET messages
        [HttpGet("{hours}")]
        public IEnumerable<MessageView> Get(int hours)
        {            
            var from = HttpContext.Request.Headers["from"].ToString();
            var to = HttpContext.Request.Headers["to"].ToString();

            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
                return _msgService?.GetMessages(hours);            
            else
                return _msgService?.GetMessages(from, to);
        }        
        
        // POST messages
        [HttpPost]
        public IActionResult Add([FromBody]MessageView newMessage)
        {
			if (newMessage == null)
			{
				return BadRequest();
			}

			_msgService.Add(newMessage);

			return Ok();
        }        
    }
}
