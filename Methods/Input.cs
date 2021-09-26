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

        protected internal static string EstadoCivil()
        {
            Console.WriteLine("Estado Civil:");

            foreach (int i in Enum.GetValues(typeof(EstadoCivil)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(EstadoCivil), i));
            }

            bool input = true;
            int output = 0;

            do
            {
                Console.WriteLine();
                Console.Write("Digite o número da opção: ");
                input = int.TryParse(Console.ReadLine(), out output);
            } while (!input);

            return Enum.GetName(typeof(EstadoCivil), output);
        }

        protected internal static string FichaRapida()
        {
            Console.WriteLine("Ficha Rapida:");

            foreach (int i in Enum.GetValues(typeof(FichaRapida)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(FichaRapida), i));
            }

            bool input = true;
            int output = 0;

            do
            {
                Console.WriteLine();
                Console.Write("Digite o número da opção: ");
                input = int.TryParse(Console.ReadLine(), out output);
            } while (!input);

            return Enum.GetName(typeof(FichaRapida), output);
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

            bool input = true;
            string uf;

            do
            {
                Console.WriteLine();
                Console.Write("Digite apenas a sigla do Estado: ");
                uf = Console.ReadLine();
                uf = uf.Length > 2 ? uf.Substring(0, 2) : uf;

                input = uf.Length < 2 ? false : true;

            } while (!input);

            return uf;
        }


   }
}