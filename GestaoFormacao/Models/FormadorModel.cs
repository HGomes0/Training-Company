using GestaoFormacao.Helpers;
using GestaoFormacao.Models.Constants;
using MongoDB.Bson.Serialization.Attributes;

namespace GestaoFormacao.Models
{
    [BsonIgnoreExtraElements]

    public class FormadorModel : FuncionarioModel
    {
        public string Area { get; set; }
        public string Disponibilidade { get; set; }
        public decimal ValorHora { get; set; }

        public FormadorModel() : base()
        {
            Funcao = FuncaoFuncionario.Formador;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\n" +
                   $"Área de Formação: {Area}{Environment.NewLine}" +
                   $"Disponibilidade: {Disponibilidade}{Environment.NewLine}" +
                   $"Valor Hora: {ValorHora}{Environment.NewLine}";
        }

        public new void ValidarCriar()
        {
            base.ValidarCriar();
            ValorHora = ValidacaoHelper.ValidarNumeroRange(ValorHora, (decimal)0.01);
            AreaFormacao.IsValid(Area);
            DisponibilidadeHorario.IsValid(Disponibilidade);
        }

        public new void ValidarAtualizar()
        {
            base.ValidarAtualizar();
            ValorHora = ValidacaoHelper.ValidarNumeroRange(ValorHora, (decimal)0.01);
        }

        public string ToCSV()
        {
            return $",{CSVEncode(Area)}" +
                $",{CSVEncode(Disponibilidade)}" +
                $",{CSVEncode(string.Format("{0:0.00}", ValorHora))}";
        }

        public static string CSVHeader()
        {
            return ",Área Formação,Disponibilidade,Valor Hora";
        }

        public static string EmptyCSV()
        {
            return ",N/A,N/A,N/A";
        }

        public bool SearchValue(string value)
        {
            return base.ValueSearch(value) ||
                Area.ToLower().Contains(value.ToLower()) ||
                Disponibilidade.ToLower().Contains(value.ToLower()) ||
                ValorHora.ToString().Contains(value);
        }
    }
}