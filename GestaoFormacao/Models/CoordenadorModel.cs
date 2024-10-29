using GestaoFormacao.Models.Constants;
using GestaoFormacao.Helpers;
using MongoDB.Bson.Serialization.Attributes;

namespace GestaoFormacao.Models
{
    [BsonIgnoreExtraElements]

    public class CoordenadorModel : FormadorModel
    {
        public CoordenadorModel(): base()
        {
            Funcao = FuncaoFuncionario.Coordenador;
        }

        [BsonIgnore]
        public List<FormadorModel> FormadoresRelacionados
        {
            get => GetFormadoresRelacionados();
        }

        public List<FormadorModel> GetFormadoresRelacionados()
        {
            var list = Empresa.FormadorController.Filtrar(f => f.Area == Area && f.Funcao == FuncaoFuncionario.Formador).ToList();
            if (list == null) return new List<FormadorModel>();
            return list;
        }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}