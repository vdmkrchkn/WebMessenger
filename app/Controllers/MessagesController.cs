using app.Models;
using app.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace app.Controllers
{
    [Route("api/[controller]")]
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

        // GET api/messages
        [HttpGet]
        public IEnumerable<Message> Get()
        {            
            return _msgService?.GetMessages(2);
        }

        // GET api/messages/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException("not realized");
        }

        // POST api/add !!!
        [HttpPost]
        public IActionResult Add([FromBody]Message newMessage)
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
