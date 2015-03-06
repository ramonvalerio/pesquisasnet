using System;
using System.Collections.Generic;

namespace PesquisasNet.Domain.Modelo
{
    public class Questionario
    {
        public string Titulo { get; set; }

        public Empresa Empresa { get; set; }

        public List<Pergunta> Perguntas { get; set; }
    }
}
