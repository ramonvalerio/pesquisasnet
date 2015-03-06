using System.Linq;
using PesquisasNet.Domain.Modelo;
using PesquisasNet.Domain.Interfaces.Repositories;

namespace PesquisasNet.Infra.Repository
{
    public class PesquisaRepository : RepositoryBase<Pesquisa>, IPesquisaRepository
    {
        public Pesquisa ObterPorCodigo(string codigo)
        {
            return base.context.ListAll<Pesquisa>().Where(x => x.Codigo == codigo).SingleOrDefault();
        }
    }
}
