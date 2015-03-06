using PesquisasNet.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesquisasNet.Domain.Interfaces.Services
{
    public interface IPesquisaService : IServiceBase<Pesquisa>
    {
        Pesquisa ObterPorCodigo(string codigo);
    }
}
