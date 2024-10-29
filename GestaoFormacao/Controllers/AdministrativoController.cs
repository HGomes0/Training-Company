using GestaoFormacao.Models;
using GestaoFormacao.Models.Constants;

namespace GestaoFormacao.Controllers
{
    public class AdministrativoController: GestaoLista<AdministrativoModel>
    {
        public AdministrativoController() : base(FuncionarioController.collectionName)
        {

        }

        public void ReportaA(string area)
        {
            var diretor = Empresa.DiretorController.Encontrar(d => d.AreaDiretoria == area);
        }

        public List<AdministrativoModel> Todos()
        {
            return Filtrar(x => x.Funcao == FuncaoFuncionario.Administrativo);
        }
        
        public uint Count()
        {
            return (uint)Todos().Count;
        }
    }
}