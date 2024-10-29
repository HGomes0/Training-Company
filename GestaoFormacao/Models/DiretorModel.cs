using GestaoFormacao.Helpers;
using GestaoFormacao.Models.Constants;
using MongoDB.Bson.Serialization.Attributes;

namespace GestaoFormacao.Models
{
    [BsonIgnoreExtraElements]

    public class DiretorModel : FuncionarioModel
    {
        public string TipoIsencao { get; set; }
        public decimal BonusMensal { get; set; }
        public bool CarroEmpresa { get; set; }
        public string AreaDiretoria { get; set; }

        public DiretorModel() : base()
        {
            Funcao = FuncaoFuncionario.Diretor;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\n" +
                   $"Isenção de Horário: {TipoIsencao}{Environment.NewLine}" +
                   $"Area: {AreaDiretoria}{Environment.NewLine}" +
                   $"Bónus Mensal: {BonusMensal}{Environment.NewLine}" +
                   $"Carro da Empresa: {CarroEmpresa}{Environment.NewLine}";
        }

        public new void ValidarCriar()
        {
            base.ValidarCriar();
            BonusMensal = ValidacaoHelper.ValidarNumeroRange(BonusMensal, (decimal)0.01);
            Isencao.IsValid(TipoIsencao);
            AreaFuncional.IsValid(AreaDiretoria);
        }

        public new void ValidarAtualizar()
        {
            base.ValidarAtualizar();
            BonusMensal = ValidacaoHelper.ValidarNumeroRange(BonusMensal, (decimal)0.01);
        }

        public string ToCSV()
        {
            return $",{CSVEncode(TipoIsencao)}" +
                $",{CSVEncode(AreaDiretoria)}" +
                $",{CSVEncode(string.Format("{0:0.00}", BonusMensal))}" +
                (CarroEmpresa ? ",Sim" : ",Não");
        }

        public static string CSVHeader()
        {
            return ",Isenção de Horário,Area,Bónus Mensal,Carro da Empresa";
        }

        public static string EmptyCSV()
        {
            return ",N/A,N/A,N/A,N/A";
        }
    }
}
