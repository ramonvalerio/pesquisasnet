namespace PesquisasNet.Domain.Modelo
{
    public class Empresa
    {
        public string Codigo { get; set; }

        public string Cnpj { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeLogin { get; set; }

        public string SenhaLogin { get; set; }

        public bool Ativo { get; set; }
    }
}
