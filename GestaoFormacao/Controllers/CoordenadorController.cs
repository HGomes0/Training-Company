using GestaoFormacao.Models;
using GestaoFormacao.Models.Constants;

namespace GestaoFormacao.Controllers
{
    public class CoordenadorController : GestaoLista<CoordenadorModel>
    {
        public CoordenadorController() : base(FuncionarioController.collectionName)
        {
        }

        public CoordenadorModel EncontrarCoordenador(FuncionarioModel? funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException("O utilizador não esta logado");
            return Encontrar(c => c.Id == funcionario.Id);
        }

        public string AreaCoordenadorLogado()
        {
            return EncontrarCoordenador(Empresa.FuncionarioLogado).Area;
        }
    }
}