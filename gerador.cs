using System;
using System.Security.Cryptography;

namespace GeradorSenhas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Gerador de Senhas!");

            bool executando = true;

            while (executando)
            {
                Console.WriteLine("Digite o comprimento da senha: ");
                int comprimento = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Incluir letras maiúsculas? (S/N): ");
                bool incluirMaiusculas = Console.ReadLine().ToUpper() == "S";

                Console.WriteLine("Incluir letras minúsculas? (S/N): ");
                bool incluirMinusculas = Console.ReadLine().ToUpper() == "S";

                Console.WriteLine("Incluir números? (S/N): ");
                bool incluirNumeros = Console.ReadLine().ToUpper() == "S";

                Console.WriteLine("Incluir caracteres especiais? (S/N): ");
                bool incluirEspeciais = Console.ReadLine().ToUpper() == "S";

                string senha = GerarSenha(comprimento, incluirMaiusculas, incluirMinusculas, incluirNumeros, incluirEspeciais);

                Console.WriteLine("Senha gerada: " + senha);

                Console.WriteLine("Deseja gerar outra senha? (S/N): ");
                executando = Console.ReadLine().ToUpper() == "S";
            }
        }

        static string GerarSenha(int comprimento, bool incluirMaiusculas, bool incluirMinusculas, bool incluirNumeros, bool incluirEspeciais)
        {
            const string caracteresMaiusculos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string caracteresMinusculos = "abcdefghijklmnopqrstuvwxyz";
            const string caracteresNumeros = "0123456789";
            const string caracteresEspeciais = "!@#$%^&*()";

            string caracteresPermitidos = "";

            if (incluirMaiusculas)
                caracteresPermitidos += caracteresMaiusculos;
            if (incluirMinusculas)
                caracteresPermitidos += caracteresMinusculos;
            if (incluirNumeros)
                caracteresPermitidos += caracteresNumeros;
            if (incluirEspeciais)
                caracteresPermitidos += caracteresEspeciais;

            byte[] dadosAleatorios = new byte[comprimento];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(dadosAleatorios);
            }

            StringBuilder senha = new StringBuilder(comprimento);
            foreach (byte b in dadosAleatorios)
            {
                senha.Append(caracteresPermitidos[b % (caracteresPermitidos.Length)]);
            }

            return senha.ToString();
        }
    }
}