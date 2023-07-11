using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application.Service.Criptografia
{
    public class EncriptadorPassword
    {
        private readonly string _chaveDeEncriptacao;

        public EncriptadorPassword(string chaveDeEncriptacao)
        {
            _chaveDeEncriptacao = chaveDeEncriptacao;
        }
        public string Criptografar(string senha)
        {
            var senhaChaveEnctiptacao = $"{senha}{_chaveDeEncriptacao}";


            var bytes = Encoding.UTF8.GetBytes(senha);
            var sha512 = SHA512.Create();
            byte[] hash = sha512.ComputeHash(bytes);
            return StringBytes(hash);
        }

        public static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
