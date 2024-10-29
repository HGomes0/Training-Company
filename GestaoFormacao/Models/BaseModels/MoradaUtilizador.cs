using GestaoFormacao.Helpers;

namespace GestaoFormacao.Models.BaseModels
{
    public class MoradaUtilizador
    {
        public string Distrito { get; set; }
        public string Localidade { get; set; }
        public string CodigoPostal { get; set; }
        public string Rua { get; set; }

        public void ValidarCriar()
        {
            if (string.IsNullOrWhiteSpace(Localidade) ||
                string.IsNullOrWhiteSpace(CodigoPostal) ||
                string.IsNullOrWhiteSpace(Rua) ||
                string.IsNullOrWhiteSpace(Distrito))
                throw new System.ArgumentNullException();

            Localidade = ValidacaoHelper.ValidarStringTamanho(Localidade, 3);
            CodigoPostal = ValidacaoHelper.ValidarCodigoPostal(CodigoPostal);
            Rua = ValidacaoHelper.ValidarStringTamanho(Rua, 3);
            Distrito = ValidacaoHelper.ValidarDistrito(Distrito);
        }

        public void ValidarAtualizar()
        {
            ValidarCriar();
        }

        public override string ToString()
        {
            return $"{Rua}, {CodigoPostal} {Localidade}, {Distrito}";
        }

        public string ToCSV()
        {
            return $"{CSVEncode(Rua)},{CSVEncode(CodigoPostal)},{CSVEncode(Localidade)},{CSVEncode(Distrito)}";
        }

        protected string CSVEncode(string value)
        {
            return value.Replace(",", ";");
        }

        public static string ToCSVHeader()
        {
            return "Rua,CodigoPostal,Localidade,Distrito";
        }
    }
}