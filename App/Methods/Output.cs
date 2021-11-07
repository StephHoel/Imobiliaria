using System;

namespace App.Methods
{
   public class Output
   {
      public static void MenuLogin()
      {
         Console.WriteLine("1- Novo Usuário");
         Console.WriteLine("2- Login");
         Console.WriteLine("3- Esqueci a Senha");
         Console.WriteLine("X- Sair");
         Console.WriteLine();
      }

      public static void MenuPrincipal()
      {
         Console.WriteLine("**Menu Principal**");
         Console.WriteLine("1- Novo Cliente");
         Console.WriteLine("2- Listar Clientes");
         Console.WriteLine("3- Editar Cliente");
         Console.WriteLine("4- Novo Contrato");
         Console.WriteLine("5- Listar Contratos");
         Console.WriteLine("6- Editar Contrato");
         Console.WriteLine("X- Sair");
         Console.WriteLine();
      }

      public static string RetornoMenu()
      {
         Console.Write("Informe a opção desejada: ");
         string opcao = Console.ReadLine().ToUpper();
         Console.WriteLine();
         return opcao;
      }
   }
}