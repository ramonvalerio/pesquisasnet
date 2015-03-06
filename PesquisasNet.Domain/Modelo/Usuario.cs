using System;
using System.Collections.Generic;

namespace PesquisasNet.Domain.Modelo
{
    public class Usuario
    {
        public string Nome { get; set; } 

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Token { get; set; }

        public string FotoPerfil { get; set; }

        public DateTime? DataNascimento { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool Ativo { get; set; }

        public List<Categoria> AreasInteresse { get; set; }

        public string Escolaridade { get; set; }

        public string Profissao { get; set; }

        public string Cidade { get; set; }

        public string Regiao { get; set; }

        public List<Disponibilidade> Disponibilidades { get; set; }
    }
}
