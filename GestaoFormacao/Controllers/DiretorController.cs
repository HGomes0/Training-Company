using GestaoFormacao.Helpers;
using GestaoFormacao.Models;
using GestaoFormacao.Models.Constants;

namespace GestaoFormacao.Controllers
{
    public class DiretorController: GestaoLista<DiretorModel>
    {
        public DiretorController() : base(FuncionarioController.collectionName)
        {
        }
        public DiretorModel EncontrarDiretorPorArea(string area)
        {
            return Encontrar(directorModel => directorModel.AreaDiretoria == area);
        }

        public bool RemoverDiretorExistenteDeArea(string area)
        {
            var diretor = Encontrar(directorModel => directorModel.AreaDiretoria == area);
            
            if (diretor == null)
            {
                return false; 
            }

            diretor.AreaDiretoria = AreaFuncional.Pendente;
            Atualizar(diretor);

            return true; 
        }

        public List<DiretorModel> Todos() {
            return Filtrar(x => x.AreaDiretoria != AreaFuncional.Pendente && FuncaoFuncionario.Diretor == x.Funcao);
        }

        public List<DiretorModel> TodosPendentes() {
            return Filtrar(x => x.AreaDiretoria == AreaFuncional.Pendente && FuncaoFuncionario.Diretor == x.Funcao);
        }

        public List<DiretorCustoModelView> DiretorMes(DateTime data)
        {
            var primeiroDiasMes = new DateTime(data.Year, data.Month, 1);
            var ultimoDiaMes = primeiroDiasMes.AddMonths(1).AddDays(-1);

            var lDir = Filtrar(x => x.DataInicioContrato <= ultimoDiaMes && x.DataFimContrato >= primeiroDiasMes && x.Funcao == FuncaoFuncionario.Diretor);

            List<DiretorCustoModelView> diretores = new List<DiretorCustoModelView>();

            foreach (var diretor in lDir)
            {
                var custo = new DiretorCustoModelView(diretor);
                diretores.Add(custo);
            }

            return diretores;
        }

        public uint Count()
        {
            return (uint)Todos().Count;
        }
    }
}
