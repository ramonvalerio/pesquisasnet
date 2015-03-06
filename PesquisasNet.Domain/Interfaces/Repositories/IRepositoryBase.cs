using System.Collections.Generic;

namespace PesquisasNet.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetByHashKey(object hashKey);

        T GetByHashKeyAndRangeKey(object hashKey, object rangeKey);

        IEnumerable<T> GetAll();

        void Save(T obj);

        void Delete(T obj);

        void Dispose();
    }
}
