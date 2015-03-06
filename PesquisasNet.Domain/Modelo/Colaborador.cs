using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesquisasNet.Domain.Modelo
{
    public class Colaborador
    {
        public string NomeCompleto { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string NomeLogin { get; set; }

        public string Senha { get; set; }

        public string Sexo { get; set; }

        public string Cidade { get; set; }

        public bool Ativo { get; set; }
    }
}
