using GestaoFormacao.Controllers;
using GestaoFormacao.Models;
using GestaoFormacao.Models.Constants;
using System.Text;

namespace GestaoFormacao
{
    public static class Empresa
    {
        public static List<FuncionarioModel> Funcionarios { get; set; } = new List<FuncionarioModel>();
        public static FuncionarioModel? FuncionarioLogado { get; set; }
        public static FuncionarioController FuncionarioController { get; set; } = new FuncionarioController();
        public static AdministrativoController AdministrativoController { get; set; } = new AdministrativoController();
        public static FormadorController FormadorController { get; set; } = new FormadorController();
        public static DiretorController DiretorController { get; set; } = new DiretorController();
        public static CoordenadorController CoordenadorController { get; set; } = new CoordenadorController();
        public static FormacaoController FormacaoController { get; set; } = new FormacaoController();

        public static void AtualizarListaFuncionarios(List<FuncionarioModel> funcionarios)
        {
            Funcionarios = funcionarios;
        }

        public static void ExportarFuncionariosCSV(string path)
        {
            var csv = new StringBuilder();
            csv.Append(FuncionarioModel.CSVHeader() + AdministrativoModel.CSVHeader() + DiretorModel.CSVHeader() + FormadorModel.CSVHeader() + "\n");
            foreach (var funcionario in FuncionarioController.Todos())
            {
                csv.Append(FormatarCSVString(funcionario));
            }
            try
            {
                File.WriteAllText(path + '\\' + "funcionarios.csv", csv.ToString(), Encoding.UTF8);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao guardar ficheiro");
            }
        }

        public static string FormatarCSVString(FuncionarioModel fun)
        {
            if (fun == null) return "";
            var info = new StringBuilder();
            info.Append(fun.ToCSV());

            if (fun.Funcao == FuncaoFuncionario.Administrativo)
            {
                var admin = AdministrativoController.Encontrar(x => x.Id == fun.Id);
                info.Append(admin.ToCSV());
            }
            else info.Append(AdministrativoModel.EmptyCSV());

            if (fun.Funcao == FuncaoFuncionario.Diretor)
            {
                var dir = DiretorController.Encontrar(x => x.Id == fun.Id);
                info.Append(dir.ToCSV());
            }
            else info.Append(DiretorModel.EmptyCSV());

            if (fun.Funcao == FuncaoFuncionario.Formador || fun.Funcao == FuncaoFuncionario.Coordenador)
            {
                var form = FormadorController.Encontrar(x => x.Id == fun.Id);
                info.Append(form.ToCSV());
            }
            else info.Append(FormadorModel.EmptyCSV());

            info.Append("\n");

            return info.ToString();
        }

        
    }
}