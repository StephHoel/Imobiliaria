using System;
using System.Globalization;
using System.Net.Mail;
using System.Threading;

namespace Imobiliaria
{
    public class Input
    {
        static bool resultado = true;

        /* Exemplos do Código Antigo

        protected internal static int Genero()
        {
            Console.WriteLine(); // para ganhar um espaço entre a entrada anterior e essa

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write(Environment.NewLine + "Digite o número do novo gênero: ");
            return int.Parse(Console.ReadLine());
        }

        protected internal static string Titulo()
        {
            Console.Write("Informe o novo título: ");
            return Console.ReadLine();
        }

        protected internal static int Ano()
        {
            Console.Write("Informe o novo ano de início (xxxx): ");
            return int.Parse(Console.ReadLine());
        }

        Fim dos Exemplos
        */

        // Novo Sistema
        protected internal static string PedeString(string titulo)
        {
            Console.Write(titulo);
            return Console.ReadLine();
        }

        protected internal static int Cep()
        {
            int cep;
            do
            {
                Console.Write("CEP (apenas números): ");
                string cepInput = Console.ReadLine();
                cepInput = cepInput.Length > 8 ? cepInput.Substring(0, 8) : cepInput;

                resultado = Int32.TryParse(cepInput, out cep);

                if (cepInput.Length < 8) resultado = false;
                if (resultado == false) Console.WriteLine("**Digite apenas 8 dígitos**");
            } while (resultado == false);

            return cep;
        }

        protected internal static int Numero()
        {
            int numero;
            do
            {
                Console.Write("Número (digite 0 para S/N): ");
                string numeroInput = Console.ReadLine();

                resultado = Int32.TryParse(numeroInput, out numero);

                if (resultado == false) Console.WriteLine("**Digite apenas números**");
            } while (resultado == false);

            return numero;
        }

        protected internal static string EstadoUF()
        {
            Console.WriteLine("Estado (UF)");

            foreach (int i in Enum.GetValues(typeof(EstadosUF)))
            {
                Console.WriteLine(Enum.GetName(typeof(EstadosUF), i));
            }

            bool input = false;
            string uf;

            do
            {
                Console.Write("Digite apenas a sigla do Estado: ");
                uf = Console.ReadLine();
                uf = uf.Length > 2 ? uf.Substring(0, 2) : uf;

                foreach (int i in Enum.GetValues(typeof(EstadosUF)))
                {
                    if (uf.ToUpper() == Enum.GetName(typeof(EstadosUF), i))
                    {
                        input = true;
                        break;
                    }
                }

            } while (!input);

            return uf;
        }

        protected internal static string Situacao()
        {
            Console.WriteLine("O imóvel está destinado à: ");

            foreach (int i in Enum.GetValues(typeof(Situacao)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Situacao), i));
            }

            bool input = false;
            int output = 0;

            do
            {
                Console.WriteLine();
                Console.Write("Digite o número da opção: ");
                input = int.TryParse(Console.ReadLine(), out output);
            } while (!input);

            return Enum.GetName(typeof(Situacao), output);
        }


   }
}