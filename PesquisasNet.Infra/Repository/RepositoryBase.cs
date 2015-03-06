using System;
using System.Collections.Generic;
using PesquisasNet.Domain.Interfaces.Repositories;
using PesquisasNet.Infra.Contexto;

namespace PesquisasNet.Infra.Repository
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected DDBContext context = new DDBContext();

        public T GetByHashKey(object hashKey)
        {
            return this.context.GetByHashKey<T>(hashKey);
        }

        public T GetByHashKeyAndRangeKey(object hashKey, object rangeKey)
        {
            return this.context.GetByHashKeyAndRangeKey<T>(hashKey, rangeKey);
        }

        public IEnumerable<T> GetAll()
        {
            return this.context.ListAll<T>();
        }

        public void Save(T obj)
        {
            this.context.Save<T>(obj);
        }

        public void Delete(T obj)
        {
            this.context.Delete<T>(obj);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
