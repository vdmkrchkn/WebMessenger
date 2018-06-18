using app.Models;
using System.Collections.Generic;

namespace app.Services
{
    public interface IMessageService
    {
        /// <summary>
        /// Добавить сообщение.
        /// </summary>
        /// <param name="message"><see cref="Message"/></param>
        void Add(Message message);

        /// <summary>
        /// Получение сообщений, отправленных за последние часы
        /// </summary>
        /// <param name="hours">часы</param>
        /// <returns>Коллекция сообщений, упорядоченная по дате и времени отправления</returns>
        IEnumerable<Message> GetMessages(int hours);
    }
}
