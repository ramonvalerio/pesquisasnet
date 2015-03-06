using System.Linq;
using PesquisasNet.Domain.Modelo;
using PesquisasNet.Domain.Interfaces.Repositories;

namespace PesquisasNet.Infra.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public Empresa ObterPorNome(string nome)
        {
            return base.context.ListAll<Empresa>().Where(x => x.NomeFantasia == nome).SingleOrDefault();
        }
    }
}
