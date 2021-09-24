using System;

namespace Imobiliaria
{
    public class Input
    {
        // protected internal static int Genero()
        // {
        //     Console.WriteLine(); // para ganhar um espaço entre a entrada anterior e essa

        //     // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
        //     // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        //     foreach (int i in Enum.GetValues(typeof(Genero)))
        //     {
        //         Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genero), i));
        //     }

        //     Console.Write(Environment.NewLine + "Digite o número do novo gênero: ");
        //     return int.Parse(Console.ReadLine());
        // }

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

      protected internal static string Descricao()
      {
         Console.Write("Informe a nova descrição: ");
         return Console.ReadLine();
      }

      protected internal static int Id()
        {
        	Console.Write("Digite o id da série: ");
			return int.Parse(Console.ReadLine());
        }

        protected internal static long Cpf() // funcionando
        {
            bool resultado = true;
            long cpf;
            do
            {
                Console.Write("CPF (apenas números): ");
                string cpfInput = Console.ReadLine();
                cpfInput = cpfInput.Length > 11 ? cpfInput.Substring(0, 11) : cpfInput;
                resultado = Int64.TryParse(cpfInput, out cpf);
                if(resultado == false) Console.WriteLine("Digite apenas números por favor");
            } while (resultado == false);

            return cpf;
        }

        protected internal static long Rg() // funcionando
        {
            bool resultado = true;
            long rg;
            do
            {
                Console.Write("RG (apenas números): ");
                string rgInput = Console.ReadLine();
                rgInput = rgInput.Length > 9 ? rgInput.Substring(0, 9) : rgInput;
                resultado = Int64.TryParse(rgInput, out rg);
                if(resultado == false) Console.WriteLine("Digite apenas números");
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
                    Console.WriteLine("Digite o Órgão Expedidor e o UF com uma barra (/) entre as duas informações");

            } while (output.Length != 2);

            return orgaouf;
         }

    }
}