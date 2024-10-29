using GestaoFormacao.Models;
using GestaoFormacao.Models.Constants;

namespace GestaoFormacao.Controllers
{
    public class FormadorController : GestaoLista<FormadorModel>
    {
        public FormadorController() : base(FuncionarioController.collectionName)
        {
        }

        public new List<FormadorModel> Todos()
        {
            return base.Filtrar(x => x.Funcao == FuncaoFuncionario.Formador);
        }

        public uint Count()
        {
            return (uint)Todos().Count;
        }

        public bool FormadorDisponivel(FormadorModel formador, DateTime dataInicioFormacao, DateTime dataFimFormacao)
        {
            if (formador == null)
                return false;
            DateTime dFormacaoInico = IgnorarHoras(dataInicioFormacao);
            DateTime dFormacaoFim = IgnorarHoras(dataFimFormacao);
            if (formador == null)
                return false;

            var formacoes = Empresa.FormacaoController.Filtrar(f => f.NumeroInternoFormador == formador.NumeroInterno);

            foreach (var formacao in formacoes)
            {
                DateTime dFormadorInicio = IgnorarHoras(formacao.DataInicioFormacao);
                DateTime dFormadorFim = IgnorarHoras(formacao.DataFimFormacao);
                if (dFormacaoInico <= dFormadorFim && dFormacaoFim >= dFormadorInicio)
                    return false;
            }

            return true;
        }

        public List<FormadorModel> FormadoresPorArea(string area)
        {
            return Filtrar(f => f.Area == area);
        }

        public List<FormadorModel> FormadoresPorDisponibilidade(string disponibilidade, DateTime dataInicioFormacao, DateTime dataFimFormacao, string area)
        {
            return Filtrar(
                f => f.Area == area &&
                (f.Disponibilidade == disponibilidade || f.Disponibilidade == DisponibilidadeHorario.Ambos) &&
                f.DataInicioContrato <= dataInicioFormacao && f.DataFimContrato >= dataFimFormacao
                );
        }

        public List<FormadorModel> FormadoresDisponiveis(string area, string disponibilidade, DateTime dataInicioFormacao, DateTime dataFimFormacao)
        {
            var formadores = FormadoresPorDisponibilidade(disponibilidade, dataInicioFormacao, dataFimFormacao, area);

            var disponiveis = new List<FormadorModel>();

            foreach (var formador in formadores)
            {
                if (FormadorDisponivel(formador, dataInicioFormacao, dataFimFormacao))
                    disponiveis.Add(formador);
            }

            return disponiveis;
        }


        public bool DeCoordenadorParaFormador(string area)
        {
            var formador = Filtrar(formadorModel => formadorModel.Area == area && formadorModel.Funcao == FuncaoFuncionario.Coordenador);

            if (formador.Count == 0)
            {
                return false;
            }

            foreach (var f in formador)
            {
                f.Funcao = FuncaoFuncionario.Formador;
                Atualizar(f);
            }

            return true;
        // lista de formações do formador logado, presentes e futuras (data de fim maior que a data atual)
        }
        public List<FormacaoModel> FormacoesFormador(uint numeroInterno)
        {
            return Empresa.FormacaoController.Filtrar(f => f.NumeroInternoFormador == numeroInterno && f.DataFimFormacao >= DateTime.Now);
        }

        // lista de formações do formador logado empresa.FuncionarioLogado, presentes e futuras (data de fim maior que a data atual)

        public List<FormacaoModel> FormacoesFormadorLogado()
        {
            if (Empresa.FuncionarioLogado == null)
                return new List<FormacaoModel>();
            return FormacoesFormador(Empresa.FuncionarioLogado.NumeroInterno);
        }

        private DateTime IgnorarHoras(DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day);
        }
    }

}
