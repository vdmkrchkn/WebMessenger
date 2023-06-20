using app.Models.Entities;
using System.Collections.Generic;

namespace app.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> Search(string content);
    }
}
