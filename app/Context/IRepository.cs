using System.Collections.Generic;

namespace app.Context
{
    public interface IRepository<T>
        where T : class
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
