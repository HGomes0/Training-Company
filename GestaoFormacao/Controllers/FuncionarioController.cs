using System.Linq.Expressions;
using System.Security.Authentication;
using GestaoFormacao.Helpers;
using GestaoFormacao.Models;
using GestaoFormacao.Models.Constants;



namespace GestaoFormacao.Controllers
{
    public class FuncionarioController : GestaoLista<FuncionarioModel>
    {
        public static readonly string collectionName = "Funcionarios";

        public FuncionarioController() : base(collectionName)
        {
        }

        public void Login(string email, string password)
        {
            var user = Encontrar(x => x.Email == email.Trim() && x.Password == ValidacaoHelper.EncriptarPassword(password.Trim()));

            if (user == null)
            {
                throw new AuthenticationException("Email ou password incorretos");
            }

            Empresa.FuncionarioLogado = user;
        }

        public FuncionarioModel? GetFuncionarioPorNumero(uint numeroInterno)
        {
            return Encontrar(x => x.NumeroInterno == numeroInterno);
        }

        public FuncionarioModel? UpdateDatas(uint numeroInterno, DateTime dataFim, DateTime dataRegisto)
        {
            var funcionario = GetFuncionarioPorNumero(numeroInterno);

            if (funcionario == null)
            {
                return null;
            }

            if (dataFim < funcionario.DataInicioContrato)
            {
                throw new AuthenticationException("Data fim não pode ser anterior à data de início");
            }
            else if (dataFim < DateTime.Now)
            {
                throw new AuthenticationException("Data fim não pode ser anterior à data atual");
            }
            else if (dataFim < funcionario.DataFimContrato)
            {
                throw new AuthenticationException("Data fim não pode ser anterior à data de fim pre estabelecida");
            }

            if (dataRegisto <= DateTime.Now)
            {
                throw new AuthenticationException("Data de registo não pode ser anterior à data atual");
            }
            else if (dataRegisto < funcionario.DataRegistoCriminal)
            {
                throw new AuthenticationException("Data de registo não pode ser anterior à data de registo pre estabelecida");
            }

            funcionario.DataFimContrato = dataFim;
            funcionario.DataRegistoCriminal = dataRegisto;

            Atualizar(funcionario);

            return funcionario;
        }

        public new List<FuncionarioModel> Filtrar(Expression<Func<FuncionarioModel, bool>> filtro)
        {
            return base.Filtrar(x => x.Role == RoleUtilizador.Funcionario && filtro.Compile().Invoke(x));
        }

        public new List<FuncionarioModel> Todos()
        {
            return base.Filtrar(x => x.Role == RoleUtilizador.Funcionario);
        }


        public uint Count()
        {
            return (uint)Todos().Count;
        }

        public bool NifJaExiste(string nif)
        {
            return Todos().Any(x => x.Nif.Trim() == nif);
        }

        public bool EmailJaExiste(string email)
        {
            return Todos().Any(x => x.Email.ToLower().Trim() == email);
        }

        public bool NumeroContatoJaExiste(string numeroContato)
        {
            return Todos().Any(x => x.Contato.Trim() == numeroContato);
        }
    }
}