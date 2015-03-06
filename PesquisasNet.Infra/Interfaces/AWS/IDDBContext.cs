using System.Collections.Generic;

namespace PesquisasNet.Infra.Interfaces.AWS
{
    public interface IDDBContext
    {
        T GetByHashKey<T>(object hashKey);

        IEnumerable<T> ListAll<T>();

        void Save<T>(T value);

        void Delete<T>(object hashKey);

        void Dispose();
    }
}