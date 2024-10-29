using GestaoFormacao.Models;

namespace GestaoFormacao.Helpers
{
    public class FormacaoCustoModel
    {
        public FormacaoCustoModel(FormacaoModel formacao, DateTime data)
        {
            NumeroInterno = formacao.NumeroInterno;
            Formacao = formacao.Nome;
            Grupo = formacao.Grupo;
            Area = formacao.Area;
            Horario = formacao.Horario;
            CustoFormador = formacao.ValorHora;
            NumeroInternoFormador = formacao.NumeroInternoFormador;
            Formador = formacao.NomeFormador;
            CustoMes = formacao.CalcularCustoMensal(data);
            CustoTotal = formacao.CalcularCusto();
            DiasTotais = formacao.DiasUteis;
            DataInicio = formacao.DataInicioFormacao.ToString("dd/MM/yyyy");
            DataFim = formacao.DataFimFormacao.ToString("dd/MM/yyyy");
        }
        public uint NumeroInterno
        {
            get; set;
        }
        public string Formacao
        {
            get; set;
        }
        public string Grupo
        {
            get; set;
        }
        public string Area
        {
            get; set;
        }
        public string Horario
        {
            get; set;
        }
        public decimal CustoFormador
        {
            get; set;
        }
        public uint NumeroInternoFormador { get; set; }
        public string Formador
        {
            get; set;
        }
        public decimal CustoMes
        {
            get; set;
        }

        public decimal CustoTotal
        {
            get; set;
        }
        public uint DiasTotais { get; }
        public string DataInicio
        {
            get; set;
        }

        public string DataFim
        {
            get; set;
        }
    }
}
