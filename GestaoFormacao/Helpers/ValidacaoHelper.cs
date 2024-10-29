using System.Security.Cryptography;
using System.Text;


namespace GestaoFormacao.Helpers
{
    public static class ValidacaoHelper
    {

        public static string ValidarStringNaoVazia(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new Exception("Valor não pode ser vazio");

            return valor.Trim();
        }

        public static string ValidarStringTamanho(string valor, int tamanho)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new Exception($"Valor não pode ser vazio");
            if (valor.Trim().Length < tamanho)
                throw new Exception($"Valor não pode ter menos de {tamanho} caracteres");

            return valor.Trim();
        }

        public static string ValidarStingOpcional(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? "" : valor.Trim();
        }

        public static int ValidarNumeroRange(int valor, int min, int max = int.MaxValue)
        {
            if (valor < min) throw new Exception($"Valor deve ser maior ou igual a {min}");
            if (valor > max) throw new Exception($"Valor deve ser menor ou igual a {max}");

            return valor;
        }

        public static uint ValidarNumeroRange(uint valor, uint min, uint max = uint.MaxValue)
        {
            if (valor < min) throw new Exception($"Valor deve ser maior ou igual a {min}");
            if (valor > max) throw new Exception($"Valor deve ser menor ou igual a {max}");

            return valor;
        }


        public static decimal ValidarNumeroRange(decimal valor, decimal min, decimal max = decimal.MaxValue)
        {
            if (valor < min) throw new Exception($"Valor deve ser maior ou igual a {min}");
            if (valor > max) throw new Exception($"Valor deve ser menor ou igual a {max}");
            return valor;
        }


        public static double ValidarNumeroRange(double valor, double min, double max = double.MaxValue)
        {
            if (valor < min) throw new Exception($"Valor deve ser maior ou igual a {min}");
            if (valor > max) throw new Exception($"Valor deve ser menor ou igual a {max}");

            return valor;
        }


        public static DateTime ValidarDataFutura(DateTime data)
        {
            var dataDia = new DateTime(data.Year, data.Month, data.Day);
            if (dataDia < DateTime.Now.AddDays(-1))
                throw new Exception("Data não pode ser passada");

            return dataDia;
        }

        public static DateTime ValidarDataRange(DateTime inicio, DateTime fim)
        {
            if (inicio > fim)
                throw new Exception("Data de início não pode ser maior que a data de fim");

            return inicio;
        }

        /*
         * Utilizador
         */

        public static string ValidarEmail(string email)
        {
            email = email.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email não pode ser vazio");

            if (
                !email.Contains("@") ||
                !email.Contains(".") ||
                email.Length < 5 ||
                email.IndexOf("@") > email.LastIndexOf(".") ||
                email.IndexOf("@") == 0
            )
                throw new Exception("Email inválido");

            return email;
        }

        public static string ValidarContato(string contacto)
        {
            contacto = contacto.Trim();
            if (string.IsNullOrWhiteSpace(contacto))
                throw new Exception("Contacto não pode ser vazio");

            if (contacto.Length != 9)
                throw new Exception("Contacto deve ter 9 dígitos");

            foreach (var c in contacto)
                if (!char.IsDigit(c))
                    throw new Exception("Contacto deve ser composto apenas por dígitos");
            if (contacto[0] != '2' && contacto[0] != '9')
                throw new Exception("Contacto deve começar por 2 ou 9");

            return contacto;
        }

        public static string ValidarNIf(string nif)
        {
            var nifString = nif.Trim();

            if (string.IsNullOrWhiteSpace(nifString))
                throw new Exception("NIF não pode ser vazio");

            if (nifString.Length != 9)
                throw new Exception("NIF deve ter 9 dígitos");

            // int[] multiplicadores = { 9, 8, 7, 6, 5, 4, 3, 2 };
            // int soma = 0;
            // for (int i = 0; i < 8; i++)
            // {
            //     soma += int.Parse(nifString[i].ToString()) * multiplicadores[i];
            // }
            //
            // int resto = soma % 11;
            // int digitoControlo = 0;
            // if (resto != 0 && resto != 1)
            // {
            //     digitoControlo = 11 - resto;
            // }
            //
            // return digitoControlo == int.Parse(nifString[8].ToString());

            return nif;
        }

        public static string ValidarPasswordForte(string password)
        {
            password = password.Trim();
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password não pode ser vazia");

            if (password.Length < 8)
                throw new Exception("Password deve ter pelo menos 8 caracteres");

            uint up = 0, low = 0, dig = 0;
            foreach (var c in password)
            {
                if (char.IsUpper(c))
                    up++;
                else if (char.IsLower(c))
                    low++;
                else if (char.IsDigit(c))
                    dig++;
            }

            if (up == 0 || low == 0 || dig == 0)
                throw new Exception("Password deve ter pelo menos 1 letra maiúscula, 1 letra minúscula e 1 dígito");

            return EncriptarPassword(password);
        }

        public static string EncriptarPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = md5.ComputeHash(bytes);

                var sb = new StringBuilder();
                foreach (var b in hash)
                    sb.Append(b.ToString("X2"));

                return sb.ToString();
            }
        }

        /*
         * Morada
         */

        public static readonly string[] DistritosPortugal =
        {
            "Aveiro",
            "Beja",
            "Braga",
            "Bragança",
            "Castelo Branco",
            "Coimbra",
            "Évora",
            "Faro",
            "Guarda",
            "Leiria",
            "Lisboa",
            "Portalegre",
            "Porto",
            "Santarém",
            "Setúbal",
            "Viana do Castelo",
            "Vila Real",
            "Viseu",
            "Açores",
            "Madeira"
        };

        public static string ValidarCodigoPostal(string cp)
        {
            cp = cp.Trim();
            if (string.IsNullOrWhiteSpace(cp))
                throw new Exception("O código postal não pode ser vazio");

            if (cp.Length != 8)
                throw new Exception("O código postal deve ter 8 caracteres");

            if (cp[4] != '-')
                throw new Exception("O código postal deve ter o formato 0000-000");

            var cpSplit = cp.Split('-');
            if (cpSplit.Length != 2)
                throw new Exception("O código postal deve ter o formato 0000-000");

            if (cpSplit[0].Length != 4 || cpSplit[1].Length != 3)
                throw new Exception("O código postal deve ter o formato 0000-000");

            return cp;
        }

        public static string ValidarDistrito(string distrito)
        {
            distrito = distrito.Trim();
            if (string.IsNullOrWhiteSpace(distrito))
                throw new Exception("O distrito não pode ser vazio");


            if (Array.IndexOf(DistritosPortugal, distrito) == -1)
                throw new Exception("Distrito inválido");

            return distrito;
        }
    }


    /*
     * NOTAS
     *
     * !ValidarNIf
     *
     * O NIF é constituído por nove dígitos, sendo os oito primeiros sequenciais e o último um dígito de controlo.
     * Adicionalmente, o primeiro dígito do NIF não pode ser zero nem quatro.
     * Para ser calculado o digito de controlo:
     * Multiplicar
     * o 1º digito por 9,
     * o 2.º dígito por 8,
     * o 3.º dígito por 7,
     * o 4.º dígito por 6,
     * o 5.º dígito por 5,
     * o 6.º dígito por 4,
     * o 7.º dígito por 3 e
     * o 8.º dígito por 2.
     *
     * Seguidamente somar os resultados. Calcular o resto da divisão do número por 11:
     * se o resto for 0 (zero) ou 1 (um) o dígito de controlo será 0 (zero);
     * se for outro qualquer algarismo X o dígito de controlo será o resultado da subtracção 11 – X.
     *
     * Por fim, basta ver a igualdade do dígito de controlo com o último dígito do NIF.
     * No caso de ser igual o NIF está correcto; no caso de ser diferente o NIF não é válido.
     */
}