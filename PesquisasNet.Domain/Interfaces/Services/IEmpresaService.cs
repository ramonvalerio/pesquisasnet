using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Domain.Interfaces.Services
{
    public interface IEmpresaService : IServiceBase<Empresa>
    {
        Empresa ObterPorNome(string nome);
    }
}
