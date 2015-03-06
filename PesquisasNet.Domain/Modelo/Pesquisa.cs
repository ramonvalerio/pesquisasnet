using System;

namespace PesquisasNet.Domain.Modelo
{
    public class Pesquisa
    {
        //HashKey
        public string Codigo { get; set; }

        //RangeKey
        public string Empresa { get; set; }

        public string Recrutador { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string Resumo { get; set; }

        public string ImagemPequena { get; set; }

        public string ImagemGrande { get; set; }

        public string Status { get; set; }

        public int? IdadeInicio { get; set; }

        public int? IdadeFim { get; set; }

        //public DateTime DataInicio { get; set; }

        //public DateTime DataFim { get; set; }

        public string Duracao { get; set; }

        //public DateTime DataCriacao { get; set; }

        public decimal Renumeracao { get; set; }

        //public decimal? FaixaSalarialDe { get; set; }

        //public decimal? FaixaSalarialAte { get; set; }

        public bool Homem { get; set; }

        public bool Mulher { get; set; }

        public bool Fotos { get; set; }

        public bool Ativo { get; set; }
    }
}
