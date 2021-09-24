using System;

namespace Imobiliaria
{
    public class Output
    {
        protected internal static void Titulo(string titulo)
        {
            Console.WriteLine();
            Console.WriteLine($"**{titulo}**");
        }

        protected internal static string[] Split(string s)
        {
            return s.Split('|');
        }

        protected internal static void MenuPrincipal()
		{
            Titulo("Menu Principal");
			Console.WriteLine("1- Novo Cliente");
			Console.WriteLine("2- Listar Clientes");
			Console.WriteLine("3- Editar Cliente");
			Console.WriteLine("4- Novo Contrato");
			Console.WriteLine("5- Listar Contratos");
			Console.WriteLine("6- Editar Contrato");
			Console.WriteLine("X- Sair");
		}

        protected internal static string RetornoMenu()
        {
            Console.WriteLine();
			Console.Write("Informe a opção desejada: ");
			string opcao = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcao;
        }
    }
}