namespace PesquisasNet.Domain
{
    public enum StatusPesquisa
    {
        Todos = 0,
        Disponivel = 1,
        Participada = 2,
        Fechada = 3,
        EmAndamento = 4
    }

    public enum Escolaridade
    {
        EnsinoFundamentoIncompleto = 0,
        EnsinoFundamentoCompleto = 1,
        SuperiorIncompleto = 2,
        SuperiorCompleto = 3,
        Mestrado = 4,
        Doutorado = 5
    }

    public enum Localidade
    {
        Centro = 0,
        ZonaNorte = 1,
        Zonasul = 2
    }

    public enum TipoPergunta
    {
        MultiplaEscolha = 0,
        EscalaLikert = 1
    }
}
