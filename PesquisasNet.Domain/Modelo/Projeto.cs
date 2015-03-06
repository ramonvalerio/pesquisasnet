using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesquisasNet.Domain.Modelo
{
    public class Projeto
    {
        public string Codigo { get; set; }

        public Empresa Empresa { get; set; }

        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public string Objetivo { get; set; }
    }
}
