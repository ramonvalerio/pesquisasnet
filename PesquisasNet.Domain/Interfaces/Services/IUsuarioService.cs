using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario ObterPorNome(string nome);
    }
}
