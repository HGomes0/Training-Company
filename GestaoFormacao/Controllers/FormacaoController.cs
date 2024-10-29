using GestaoFormacao.Helpers;
using GestaoFormacao.Models;

namespace GestaoFormacao.Controllers
{
    public class FormacaoController : GestaoLista<FormacaoModel>
    {
        public FormacaoController() : base("Formacao")
        {
        }

        public bool CriarFormacao(string nome, string grupo, string horario, DateTime dataInicio, DateTime dataFim, string area, uint numeroInterno)
        {
            var formador = Empresa.FormadorController.PorNumeroInterno(numeroInterno);
            if (formador == null)
            {
                return false;
            }
            try
            {
                var formacao = new FormacaoModel
                {
                    Nome = nome,
                    Grupo = grupo,
                    Horario = horario,
                    DataInicioFormacao = dataInicio,
                    DataFimFormacao = dataFim,
                    Area = area,
                    NumeroInternoFormador = numeroInterno,
                    ValorHora = formador.ValorHora,
                    NomeFormador = formador.Nome ?? ""
                };
                formacao.ValidarCriar();
                Adicionar(formacao);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<FormacaoModel> FormacoesFormador(uint numeroInterno)
        {
            return Filtrar(f => f.NumeroInterno == numeroInterno);
        }

        public decimal CalcularCustoMensal(DateTime data)
        {
            decimal custo = 0;

            data = new DateTime(data.Year, data.Month, 1);

            var formacoesIniciadas = Filtrar(f => f.DataInicioFormacao <= data && f.DataFimFormacao >= data);

            foreach (var formacao in formacoesIniciadas)
            {
                custo += formacao.CalcularCustoMensal(data);
            }

            return custo;
        }

        public List<FormacaoModel> FormacoesAOcorrer(DateTime data)
        {
            var primeiroDiasMes = new DateTime(data.Year, data.Month, 1);
            var ultimoDiaMes = primeiroDiasMes.AddMonths(1).AddDays(-1);
            return Filtrar(f => f.DataInicioFormacao <= ultimoDiaMes && f.DataFimFormacao >= primeiroDiasMes);
        }

        public List<FormacaoModel> FormacoesPorArea(string area)
        {
            return Filtrar(f => f.Area == area);
        }

        public List<FormacaoModel> GetFormacoesAtivas()
        {
            return Filtrar(f => f.DataFimFormacao >= DateTime.Today);
        }

        public List<FormacaoModel> GetTodasFormacoes()
        {
            return Todos();
        }

        public uint Count()
        {
            return (uint)Todos().Count;
        }

        public List<FormacaoModel> GetFormacoesPorMes(DateTime data)
        {
            var primeiroDiasMes = new DateTime(data.Year, data.Month, 1);
            var ultimoDiaMes = primeiroDiasMes.AddMonths(1).AddDays(-1);
            return Filtrar(f => f.DataInicioFormacao <= ultimoDiaMes && f.DataFimFormacao >= primeiroDiasMes);
        }

        public KeyValuePair<decimal, List<FormacaoCustoModel>> GetCustosFormacao(DateTime data)
        {
            var formacoes = FormacoesAOcorrer(data);

            var custos = new List<FormacaoCustoModel>();
            decimal custoTotal = 0;

            foreach (var formacao in formacoes)
            {
                var custoFormador = formacao.CalcularCustoMensal(data);
                custoTotal += custoFormador;

                custos.Add(
                    new FormacaoCustoModel(formacao, data)
                );
            }

            return new KeyValuePair<decimal, List<FormacaoCustoModel>>(custoTotal, custos);
        }
    }
}

