using app.Models.ViewModels;
using System.Collections.Generic;

namespace app.Services
{
    public interface IMessageService
    {
        /// <summary>
        /// Добавить сообщение.
        /// </summary>
        /// <param name="message"><see cref="MessageView"/></param>
        void Add(MessageView message);

        /// <summary>
        /// Получение сообщений, отправленных за последние часы.
        /// </summary>
        /// <param name="hours">кол-во часов</param>
        /// <returns>Коллекция сообщений</returns>
        IEnumerable<MessageView> GetMessages(int hours);

        /// <summary>
        /// Получение сообщений, отправленных за определённый временной интервал.
        /// </summary>
        /// <param name="beginDate">начало интервала</param>
        /// <param name="endDate">конец интервала</param>
        /// <returns>Коллекция сообщений</returns>
        IEnumerable<MessageView> GetMessages(string beginDate, string endDate);
    }
}
