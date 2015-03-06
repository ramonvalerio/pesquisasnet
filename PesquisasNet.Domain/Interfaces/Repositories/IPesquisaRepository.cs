using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Domain.Interfaces.Repositories
{
    public interface IPesquisaRepository : IRepositoryBase<Pesquisa>
    {
        Pesquisa ObterPorCodigo(string codigo);
    }
}
