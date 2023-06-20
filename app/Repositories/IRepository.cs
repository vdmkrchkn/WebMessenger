using app.Models.Entities;
using System.Collections.Generic;

namespace app.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        // получить список сущностей
        IEnumerable<T> GetItemList();
        // получить сущность по id
        T GetItemById(int id);
        // создать сущность
        void Create(T item);
        // сохранить все изменения контекста
        void Save();
    }
}
