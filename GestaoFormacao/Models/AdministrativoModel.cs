using GestaoFormacao.Models.Constants;
using MongoDB.Bson.Serialization.Attributes;

namespace GestaoFormacao.Models
{
    [BsonIgnoreExtraElements]

    public class AdministrativoModel : FuncionarioModel
    {
        public string AreaAdministracao { get; set; }

        [BsonIgnore]
        public string ReportaA
        {
            get => string.IsNullOrEmpty(AreaAdministracao)
            ? "N/A"
            : Empresa.DiretorController.EncontrarDiretorPorArea(AreaAdministracao)?.Nome ?? "N/A";
        }

        public AdministrativoModel(): base()
        {
            Funcao = FuncaoFuncionario.Administrativo;
        }

        public override string ToString()
        {
            return base.ToString() + $"Área de Secretariado: {AreaAdministracao}";
        }
        
        public new void ValidarCriar()
        {
            base.ValidarCriar();
            AreaFuncional.IsValid(AreaAdministracao);
        }
        
        public new void ValidarAtualizar()
        {
            base.ValidarAtualizar();
        }

        public string ToCSV()
        {
            return $",{CSVEncode(AreaAdministracao)}";
        }

        public static string CSVHeader()
        {
            return ",Area Administrativa";
        }

        public static string EmptyCSV()
        {
            return ",N/A";
        }
    }
}