using System.Collections.Generic;

namespace PesquisasNet.Domain.Modelo
{
    public class Profissao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Usuario> Participantes { get; set; }
    }
}
