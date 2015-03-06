using System;
using System.Collections.Generic;
using PesquisasNet.Domain.Interfaces.Services;
using PesquisasNet.Domain.Interfaces.Repositories;

namespace PesquisasNet.Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this._repository = repository;
        }

        public T GetByHashKey(object hashKey)
        {
            if (hashKey == null)
                return null;

            if (hashKey.ToString() == string.Empty)
                return null;

            return this._repository.GetByHashKey(hashKey);
        }

        public T GetByHashKeyAndRangeKey(object hashKey, object rangeKey)
        {
            if (hashKey == null || rangeKey == null)
                return null;

            if (hashKey.ToString() == string.Empty || rangeKey.ToString() == string.Empty)
                return null;

            return this._repository.GetByHashKeyAndRangeKey(hashKey, rangeKey);
        }

        public IEnumerable<T> GetAll()
        {
            return this._repository.GetAll();
        }

        public void Save(T obj)
        {
            this._repository.Save(obj);
        }

        public void Delete(T obj)
        {
            this._repository.Delete(obj);
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
