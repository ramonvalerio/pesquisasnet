namespace PesquisasNet.Domain.Modelo
{
    public class Disponibilidade
    {
        public int Id { get; set; }

        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }

        public Usuario Participante { get; set; }
        public DiaSemana DiaSemana { get; set; }
    }
}
