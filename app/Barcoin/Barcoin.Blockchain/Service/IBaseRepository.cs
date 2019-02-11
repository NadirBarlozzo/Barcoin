using System.Collections.Generic;

namespace Barcoin.Blockchain.Service
{
    public interface IBaseRepository<T>
    {
        T Get(int id);
        List<T> Get();

        int Add(T item);
    }
}
