namespace GestaoFormacao.Interfaces
{
    public interface IFormUpdateDatas
    {
        public uint NumeroInterno { set; get; }
        public string Nome { set; }
        public string Nif { set; }
        public string Funcao { set; }
        public string DataInicio { set; }
        public DateTime DataFim { set; get; }
        public DateTime DataRegisto { set; get; }

        public event EventHandler<DateTime> UpdateDataFim;
        public event EventHandler<DateTime> UpdateDataRegisto;
        public event EventHandler Confirmar;

        public string ErroDataFim { set; }
        public string ErroDataRegisto { set; }

        public void Fechar();

        public void Mostrar();
    }
}
