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

        protected internal static long Cpf()
        {
            long cpf;
            do
            {
                Console.Write("CPF (apenas números): ");
                string cpfInput = Console.ReadLine();
                cpfInput = cpfInput.Length > 11 ? cpfInput.Substring(0, 11) : cpfInput;
                resultado = Int64.TryParse(cpfInput, out cpf);
                if(resultado == false) Console.WriteLine("**Digite apenas números**");
            } while (resultado == false);

            return cpf;
        }

        protected internal static long Rg()
        {
            long rg;
            do
            {
                Console.Write("RG (apenas números): ");
                string rgInput = Console.ReadLine();
                rgInput = rgInput.Length > 9 ? rgInput.Substring(0, 9) : rgInput;
                resultado = Int64.TryParse(rgInput, out rg);
                if(resultado == false) Console.WriteLine("**Digite apenas números**");
            } while (resultado == false);

            return rg;
        }

        protected internal static string PedeString(string titulo)
        {
            Console.Write(titulo);
            return Console.ReadLine();
        }

        protected internal static string OrgaoUF(string titulo)
        {
            string[] output;
            string orgaouf;

            do
            {
                Console.Write(titulo);
                orgaouf = Console.ReadLine();

                output = orgaouf.Split('/');

                if (output.Length != 2)
                    Console.WriteLine("**Use uma barra (/) entre o Órgão Expedidor e o UF**");

            } while (output.Length != 2);

            return orgaouf;
         }

        protected internal static string DataNasc()
        {
            DateTime data;
            string linha;

            do
            {
                Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
                linha = Console.ReadLine();

                resultado = DateTime.TryParse(linha, new CultureInfo("pt-BR"), DateTimeStyles.None, out data);

                if (!resultado)
                {
                    Console.WriteLine("**Use o formato correto (dd/mm/aaaa)**");
                }

            } while (!resultado);

            return data.ToString("dd/MM/yyyy");
        }

        protected internal static string Email()
        {
            string email;

            do
            {
                Console.Write("Email (exemplo@exemplo.com): ");
                email = Console.ReadLine();

                var addr = new MailAddress(email);
                resultado = addr.Address.Equals(email);

                if(!resultado)
                    Console.WriteLine("**Digite corretamente o email**");

            } while (!resultado);

            return email;
      }
    }
}