using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        Empresa ObterPorNome(string nome);
    }
}
