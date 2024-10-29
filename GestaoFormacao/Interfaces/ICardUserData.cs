namespace GestaoFormacao.Interfaces
{
    internal interface ICardUserData
    {
        public uint NumeroInterno { get; set; }
        public string UserName { get; set; }
        public string UserFunction { get; set; }
        public string UserMessage { get; set; }
    }
}