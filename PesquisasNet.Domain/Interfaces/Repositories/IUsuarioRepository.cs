using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ObterPorNome(string nome);
    }
}
