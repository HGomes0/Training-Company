using GestaoFormacao.Helpers;
using GestaoFormacao.Models.Constants;
using MongoDB.Bson.Serialization.Attributes;

namespace GestaoFormacao.Models
{
    [BsonIgnoreExtraElements]
    public class FuncionarioModel : UtilizadorModel
    {

        public DateTime DataInicioContrato { get; set; }

        public DateTime DataFimContrato { get; set; }

        public DateTime DataRegistoCriminal { get; set; }

        public string Funcao { get; set; }

        public FuncionarioModel()
        {
            Role = RoleUtilizador.Funcionario;
        }

        public string? getAvisosDocumentosACaducar(DateTime dataAverificar)
        {
            string mensagem = "";


            int diasContrato = (DataFimContrato - dataAverificar).Days;
            if (diasContrato > 0 && diasContrato < 30)
            {
                mensagem += "O Contrato termina em " + diasContrato + " dias." + Environment.NewLine;
            }
            else if (diasContrato < -31)
            {
                return null;
            }
            else if (diasContrato < 0)
            {
                mensagem += "O Contrato terminou há " + diasContrato * -1 + " dias." + Environment.NewLine;
            }
            else if (diasContrato == 0)
            {
                mensagem += "O Contrato termina hoje." + Environment.NewLine;
            }

            int diasRegistoCriminal = (DataRegistoCriminal - dataAverificar).Days;
            if (diasRegistoCriminal > 0 && diasRegistoCriminal < 30)
            {
                mensagem += "O Registo Criminal caduca em " + diasRegistoCriminal + " dias.";
            }
            else if (diasRegistoCriminal < 0)
            {
                mensagem += "O Registo Criminal caducou há " + diasRegistoCriminal * -1 + " dias.";
            }
            else if (diasRegistoCriminal == 0)
            {
                mensagem += "O Registo Criminal caduca hoje.";
            }

            return string.IsNullOrEmpty(mensagem) ? null : mensagem;
        }

        public void setDataRegistoCriminal(DateTime dataRegistoCriminal)
        {
            if (dataRegistoCriminal < DateTime.Now || dataRegistoCriminal < DataInicioContrato)
            {
                throw new Exception("Data de registo criminal inválida");
            }

            this.DataRegistoCriminal = dataRegistoCriminal;
        }

        public void setDataFimContrato(DateTime dataFimContrato)
        {
            if (dataFimContrato < DateTime.Now || dataFimContrato < DataInicioContrato)
            {
                throw new Exception("Data de fim de contrato inválida");
            }

            this.DataFimContrato = dataFimContrato;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"Função: {Funcao}{Environment.NewLine}" +
                   $"Inicio de Contrato: {DataInicioContrato}{Environment.NewLine}" +
                   $"Fim de Contrato: {DataFimContrato}{Environment.NewLine}" +
                   $"Validade do Registo Criminal: {DataRegistoCriminal}{Environment.NewLine}";
        }

        public new void ValidarCriar()
        {
            base.ValidarCriar();
            DataInicioContrato = ValidacaoHelper.ValidarDataFutura(DataInicioContrato);
            DataFimContrato = ValidacaoHelper.ValidarDataFutura(DataFimContrato);
            DataRegistoCriminal = ValidacaoHelper.ValidarDataFutura(DataRegistoCriminal);

            ValidacaoHelper.ValidarDataRange(DataInicioContrato, DataFimContrato);
        }

        public new void ValidarAtualizar()
        {
            base.ValidarAtualizar();
            DataFimContrato = ValidacaoHelper.ValidarDataFutura(DataFimContrato);
            DataRegistoCriminal = ValidacaoHelper.ValidarDataFutura(DataRegistoCriminal);
        }

        public new string ToCSV()
        {
            string result = base.ToCSV()
            + $",{CSVEncode(Funcao)}"
            + $",{CSVEncode(DataInicioContrato.ToString("yyyy-MM-dd"))}"
            + $",{CSVEncode(DataFimContrato.ToString("yyyy-MM-dd"))}"
            + $",{CSVEncode(DataRegistoCriminal.ToString("yyyy-MM-dd"))}";

            return result;
        }

        public new static string CSVHeader()
        {
            return UtilizadorModel.CSVHeader() + ",Funcao,DataInicioContrato,DataFimContrato,DataRegistoCriminal";
        }

        public bool ValueSearch(string search)
        {
            return base.ValueSearch(search) || $"{Funcao} {DataInicioContrato.ToString("yyyy-MM-dd")} {DataFimContrato.ToString("yyyy-MM-dd")} {DataRegistoCriminal.ToString("yyyy-MM-dd")}".Contains(search);
        }
    }
}