using System.Collections.Generic;

namespace Launcher.Service
{
    interface IBaseRepository<T>
    {
        T Get(int id);
        List<T> Get();

        void Add(T item);

        void Delete(T item);
    }
}
