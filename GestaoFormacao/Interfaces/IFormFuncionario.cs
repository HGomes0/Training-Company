namespace GestaoFormacao.Interfaces
{
    public interface IFormFuncionario
    {
        event EventHandler AnteriorClick;
        event EventHandler SeguinteClick;
        public string BtnProximoText { set; }
        public string BtnAnteriorText { set; }

        public bool BtnAnteriorVisible { set; }
        public bool BtnProximoEnabled { set; }

        public IFormUtilizadorControl UtilizadorControl { get; }
        public bool UtilizadorControlVisible { set; }
        public IFormFuncionarioControl FuncionarioControl { get; }
        public bool FuncionarioControlVisible { set; }
        public IFormAdministrativoControl AdministrativoControl { get; }
        public bool AdministrativoControlVisible { set; }

        public IFormFormadorControl FormadorControl { get; }
        public bool FormadorControlVisible { set; }
        public IFormDiretorControl DiretorControl { get; }
        public bool DiretorControlVisible { set; }

        public void Fechar();

    }
}
