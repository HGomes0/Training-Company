namespace GestaoFormacao.Models.Constants
{
    public static class AreaFormacao
    {
        public const string Geral = "Geral";
        public const string NegociosGestao = "Negócios e Gestão";
        public const string SaudeSeguranca = "Saúde e Segurança";
        public const string RecursosHumanos = "Recursos Humanos";
        public const string MarketingVendas = "Marketing e Vendas";
        public const string ArtesDesign = "Artes e Design";
        public const string CienciaEngenharia = "Ciência e Engenharia";
        public const string Idiomas = "Idiomas";
        public const string FinancasContabilidade = "Finanças e Contabilidade";
        public const string TecnologiaInformacao = "Tecnologia da Informação";
        public const string LiderancaDesenvolvimentoPessoal = "Liderança e Desenvolvimento Pessoal";
        public const string AtendimentoCliente = "Atendimento ao Cliente";
        public const string ComunicacaoApresentacao = "Comunicação e Apresentação";
        public const string DireitoRegulamentacao = "Direito e Regulamentação";

        public static bool IsValid(string area)
        {
            return area switch
            {
                Geral => true,
                NegociosGestao => true,
                SaudeSeguranca => true,
                RecursosHumanos => true,
                MarketingVendas => true,
                ArtesDesign => true,
                CienciaEngenharia => true,
                Idiomas => true,
                FinancasContabilidade => true,
                TecnologiaInformacao => true,
                LiderancaDesenvolvimentoPessoal => true,
                AtendimentoCliente => true,
                ComunicacaoApresentacao => true,
                DireitoRegulamentacao => true,
                _ => false
            };
        }

        public static List<string> GetAll()
        {
            return new List<string>
                {
                    Geral,
                    NegociosGestao,
                    SaudeSeguranca,
                    RecursosHumanos,
                    MarketingVendas,
                    ArtesDesign,
                    CienciaEngenharia,
                    Idiomas,
                    FinancasContabilidade,
                    TecnologiaInformacao,
                    LiderancaDesenvolvimentoPessoal,
                    AtendimentoCliente,
                    ComunicacaoApresentacao,
                    DireitoRegulamentacao
                };
        }
    }
}