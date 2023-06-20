using System.Collections.Generic;

namespace app.Models.Entities
{
    public enum Estate
    {
        Online,
        Offline
    }

    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public Estate State { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
