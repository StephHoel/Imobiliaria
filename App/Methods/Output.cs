using System;
using Lib.Methods;
using Microsoft.VisualBasic;

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
         Console.WriteLine();

         Console.WriteLine("1- Listar");
         Console.WriteLine("2- Novo");
         Console.WriteLine("3- Editar");
         Console.WriteLine("4- Excluir");
         Console.WriteLine("X- Sair");
         Console.WriteLine();
      }

      public static void MenuInterno(int o)
      {
         switch (o)
         {
            case 1: // Listar
               Console.WriteLine("1- Listar Cliente");
               Console.WriteLine("2- Listar Imóvel");
               Console.WriteLine("3- Listar Contrato");
               Console.WriteLine("4- Listar Usuário");
               break;

            case 2: // Novo
               Console.WriteLine("1- Novo Cliente");
               Console.WriteLine("2- Novo Endereço");
               Console.WriteLine("3- Novo Telefone");
               Console.WriteLine("4- Novo Imóvel");
               Console.WriteLine("5- Novo Contrato");
               Console.WriteLine("6- Novo Usuário");
               break;

            case 3: // Editar
               Console.WriteLine("1- Editar Cliente");
               Console.WriteLine("2- Editar Endereço");
               Console.WriteLine("3- Editar Telefone");
               Console.WriteLine("4- Editar Imóvel");
               Console.WriteLine("5- Editar Contrato");
               Console.WriteLine("6- Editar Usuário");
               break;

            case 4: // Excluir
               Console.WriteLine("1- Excluir Cliente");
               Console.WriteLine("2- Excluir Endereço");
               Console.WriteLine("3- Excluir Telefone");
               Console.WriteLine("4- Excluir Imóvel");
               Console.WriteLine("5- Excluir Contrato");
               Console.WriteLine("6- Excluir Usuário");
               break;

            default:
               break;
         }
      }

      public static string RetornoMenu()
      {
         Console.Write("Informe a opção desejada: ");
         string opcao = Console.ReadLine().ToUpper();
         Console.WriteLine();
         return opcao;
      }

      public static string Editar(string input)
      {
         string info = input;
         Console.Write(input);
         do
         {
            ConsoleKeyInfo key = Console.ReadKey(true);
            // Backspace Should Not Work
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
               info += key.KeyChar;
               Console.Write(key.KeyChar);
            }
            else
            {
               if (key.Key == ConsoleKey.Backspace && info.Length > 0)
               {
                  info = info[0..^1];
                  Console.Write("\b \b");
               }
               else if (key.Key == ConsoleKey.Enter)
               {
                  Console.WriteLine();
                  break;
               }
            }
         } while (true);

         return info;
      }

      public static string DoWhile(string texto, string metodo, string input = null, string opcao = null)
      {
         string info = "", erro;

         do
         {
            Console.Write(texto);

            //switch aqui para verificar metodo
            switch (metodo)
            {
               // Funções para Adicionar
               case "Add cpf":
                  info = MCliente.Cpf(Console.ReadLine());
                  erro = "**Digite apenas números**";
                  break;
               case "Add texto":
                  info = Geral.RetornaString(Console.ReadLine());
                  erro = "**Campo vazio inválido**";
                  break;
               case "Add rg":
                  info = MCliente.Rg(Console.ReadLine());
                  erro = "**Digite apenas números**";
                  break;
               case "Add uf":
                  info = Geral.Uf(Console.ReadLine());
                  erro = "**UF Inválido**";
                  break;
               case "Add data":
                  info = MCliente.DataNasc(Console.ReadLine());
                  erro = "**Use o formato correto (dd/mm/aaaa)**";
                  break;
               case "Add opção":
                  info = Geral.Enums(Console.ReadLine(), input);
                  erro = "**Digite uma opção válida**";
                  break;
               case "Add email":
                  info = Geral.Email(Console.ReadLine());
                  erro = "**Digite corretamente o e-mail**";
                  break;

               // Funções para Editar
               case "Editar cpf":
                  info = MCliente.Cpf(Editar(MCliente.Normalize(input)));
                  erro = "**Digite apenas números**";
                  break;
               case "Editar texto":
                  info = Geral.RetornaString(Editar(input));
                  erro = "**Campo vazio inválido**";
                  break;
               case "Editar rg":
                  info = MCliente.Rg(Editar(MCliente.Normalize(input)));
                  erro = "**Digite apenas números**";
                  break;
               case "Editar uf":
                  info = Geral.Uf(Editar(input));
                  erro = "**UF Inválido**";
                  break;
               case "Editar data":
                  info = MCliente.DataNasc(Editar(input));
                  erro = "**Use o formato correto (dd/mm/aaaa)**";
                  break;
               case "Editar opção":
                  info = Geral.Enums(Editar(input), opcao);
                  erro = "**Digite uma opção válida**";
                  break;
               case "Editar email":
                  info = Geral.Email(Editar(input));
                  erro = "**Digite corretamente o e-mail**";
                  break;

               default:
                  erro = "Erro na aplicação";
                  break;
            }

            if (info == "")
               Console.WriteLine(erro);

            Console.WriteLine();
         } while (info == "");

         return info;
      }

      public static void Vazio(int i)
      {
         if (i == 0)
         {
            Console.WriteLine();
            Console.WriteLine("Sem registros");
         }
      }
   }
}