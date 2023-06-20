using app.Context;
using app.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace app.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(EFDbContext context) : base(context)
        {
        }

        public override IEnumerable<Message> GetItemList() 
        {
            return Entities.Include(message => message.Contact)
                .AsEnumerable();
        }

        public IEnumerable<Message> Search(string content)
        {
            return base.GetItemList()
                .Where(message => message.Content.Contains(content));
        }
    }
}
