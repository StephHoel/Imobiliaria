using System;

namespace App.Methods
{
   public class MenuLogin
   {
      public static void Menu()
      {
         string opcao, user;
         do
         {
            Output.MenuLogin();
            opcao = Output.RetornoMenu();

            switch (opcao)
            {
               case "1":
                  EntradaUsuario.Novo();
                  break;
               case "2":
                  user = EntradaUsuario.Login();
                  if (user != "")
                  {
                     Console.WriteLine();

                     MenuPrincipal.Menu();

                  }
                  break;
               case "3":
                  EntradaUsuario.EsqueciSenha();
                  break;
               case "X":
                  break;
               default:
                  Console.WriteLine("**Opção Inválida**");
                  break;
            }
            Console.WriteLine();
         } while (opcao.ToUpper() != "X");

      }
   }
}