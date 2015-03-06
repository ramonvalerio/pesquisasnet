using PesquisasNet.Domain.Modelo;
using PesquisasNet.Domain.Interfaces.Services;
using PesquisasNet.Domain.Interfaces.Repositories;

namespace PesquisasNet.Domain.Services
{
    public class PesquisaService : ServiceBase<Pesquisa>, IPesquisaService
    {
        private readonly IPesquisaRepository _pesquisaRepository;

        public PesquisaService(IPesquisaRepository pesquisaRepository)
            : base(pesquisaRepository)
        {
            _pesquisaRepository = pesquisaRepository;
        }

        public Pesquisa ObterPorCodigo(string codigo)
        {
            return _pesquisaRepository.ObterPorCodigo(codigo);
        }
    }
}
