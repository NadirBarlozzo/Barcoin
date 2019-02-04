using System.Collections.Generic;

namespace Barcoin.Client.Service
{
    interface IBaseRepository<T>
    {
        T Get(int id);
        List<T> Get();

        void Add(T item);

        void Update(T item);

        void Delete(int id);
    }
}
