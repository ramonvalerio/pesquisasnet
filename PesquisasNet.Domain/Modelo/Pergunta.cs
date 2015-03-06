using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesquisasNet.Domain.Modelo
{
    public class Pergunta
    {
        public string Texto { get; set; }

        public TipoPergunta TipoPergunta { get; set; }

        public string Resposta { get; set; }
    }
}
