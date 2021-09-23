using System.Security.Cryptography;
using System.Text;

namespace BuiltCode.Application.AppServices
{
    public static class HashService
    {
        private static HashAlgorithm _algoritmo = MD5.Create();

        public static string GerarHash(string texto)
        {
            var valorCodificado = Encoding.UTF8.GetBytes(texto);
            var encript = _algoritmo.ComputeHash(valorCodificado);
            var sb = new StringBuilder();
            foreach (var caractere in encript)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return sb.ToString();
        }
        public static bool CompararHash(string texto1, string texto2)
        {
            var encript = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(texto1));
            var sb = new StringBuilder();
            foreach (var caractere in encript)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return sb.ToString() == texto2;
        }
    }
}
