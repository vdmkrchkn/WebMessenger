using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        // GET api/messages
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "message1", "message2" };
        }

        // GET api/messages/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "message";
        }

        // POST api/messages
        [HttpPost]
        public void Post([FromBody]string message)
        {
        }

        // PUT api/messages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string message)
        {
        }

        // DELETE api/messages/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
