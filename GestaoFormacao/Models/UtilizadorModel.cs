using GestaoFormacao.Database;
using GestaoFormacao.Helpers;
using GestaoFormacao.Interfaces;
using GestaoFormacao.Models.BaseModels;

namespace GestaoFormacao.Models
{
    public class UtilizadorModel : GFMongoEntity, IIdentificavel
    {
        // Propriedades
        private uint nInterno;
        public uint NumeroInterno
        {
            get => nInterno == 0 ? GFOption.GetNextIDUtilizador() : nInterno;
            set => nInterno = value;
        }

        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Nif { get; set; }
        public string? Contato { get; set; }
        public MoradaUtilizador? Morada { get; set; }
        public string Role { get; set; }

        // Validaçoes
        public void ValidarCriar()
        {
            if (Nome == null || Email == null || Password == null || Nif == null || Contato == null || Role == null || Morada == null)
                throw new ArgumentNullException();
            Nome = ValidacaoHelper.ValidarStringTamanho(Nome, 3);
            Email = ValidacaoHelper.ValidarEmail(Email);
            Password = ValidacaoHelper.ValidarPasswordForte(Password);
            Nif = ValidacaoHelper.ValidarNIf(Nif);
            Contato = ValidacaoHelper.ValidarContato(Contato);
            Morada.ValidarCriar();

            if (Empresa.FuncionarioController.EmailJaExiste(Email))
            {
                throw new Exception("Email já existe");
            }

            if (Empresa.FuncionarioController.NifJaExiste(Nif))
            {
                throw new Exception("NIF já existe");
            }

            if (Empresa.FuncionarioController.NumeroContatoJaExiste(Contato))
            {
                throw new Exception("Contacto já existe");
            }
        }

        public void ValidarAtualizar()
        {
            if (Nome == null || Email == null || Password == null || Nif == null || Contato == null || Role == null || Morada == null)
                throw new ArgumentNullException();
            Nome = ValidacaoHelper.ValidarStringTamanho(Nome, 3);
            Email = ValidacaoHelper.ValidarEmail(Email);
            Nif = ValidacaoHelper.ValidarNIf(Nif);
            Contato = ValidacaoHelper.ValidarContato(Contato);
            Morada.ValidarCriar();
        }

        // Overrides
        public override string ToString()
        {
            return base.ToString() +
                   $"Nome: {Nome}{Environment.NewLine}" +
                   $"E-mail: {Email}{Environment.NewLine}" +
                   $"NIF: {Nif}{Environment.NewLine}" +
                   $"Contacto: {Contato}{Environment.NewLine}" +
                   $"Morada: {Morada}{Environment.NewLine}";
        }

        public string ToCSV()
        {
            return $"{CSVEncode(NumeroInterno.ToString())},{CSVEncode(Nome)},{CSVEncode(Email)},{CSVEncode(Nif)},{CSVEncode(Contato)},{CSVEncode(Role)},{Morada.ToCSV()}";
        }

        protected string CSVEncode(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value.Replace(",", ";");
            } else {
                return "-";
            }
        }

        public static string CSVHeader()
        {
            return "NumeroInterno,Nome,Email,Nif,Contato,Role," + MoradaUtilizador.ToCSVHeader();
        }

        public bool ValueSearch(string search)
        {
            string item = $"{Nome} {Email} {Nif} {Contato} {Morada?.Rua ?? ""} {Morada?.CodigoPostal ?? ""} {Morada?.Localidade ?? ""} {Morada?.Distrito ?? ""}".ToLower();

            return item.Contains(search.ToLower());
        }
    }
}