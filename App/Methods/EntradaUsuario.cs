using System;
using Lib.Classes;
using Lib.Methods;
using Lib.Repositorio;

namespace App.Methods
{
   public class EntradaUsuario
   {
      static readonly UsuarioRepositorio repositorio = new();

      protected internal static void NovoUsuario()
      {
         int id = repositorio.ProximoId();

         Console.WriteLine();

         // Nome
         string usuario;
         do
         {
            Console.Write("Usuário: ");
            usuario = Geral.RetornaString(Console.ReadLine());

            if (usuario == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (usuario == "");

         // Email
         string email;
         do
         {
            Console.Write("E-mail (ex@exemp.lo): ");
            email = Geral.Email(Console.ReadLine());

            if (email == "")
               Console.WriteLine("**Digite corretamente o e-mail**");
         } while (email == "");

         // Senha
         string senha;
         do
         {
            Console.Write("Senha: ");
            senha = Password();

            if (senha == "")
               Console.WriteLine("**Digite uma senha**");
         } while (senha == "");

         Usuario user = new(id, usuario, email, senha);

         string user2 = $"{id}|{usuario}|{email}|{senha}|{false}";

         repositorio.Insere(user, user2);

         Console.WriteLine();
         Console.WriteLine("**Usuário cadastrado com sucesso**");
         Console.WriteLine();


      }

      private static string Password()
      {
         string senha = "";
         do
         {
            ConsoleKeyInfo key = Console.ReadKey(true);
            // Backspace Should Not Work
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
               senha += key.KeyChar;
               Console.Write("*");
            }
            else
            {
               if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
               {
                  senha = senha[0..^1];
                  Console.Write("\b \b");
               }
               else if (key.Key == ConsoleKey.Enter)
               {
                  Console.WriteLine();
                  break;
               }
            }
         } while (true);
         return Encriptografia.Encrypt(senha);
      }

      protected internal static string Login()
      {
         Console.WriteLine();

         // Usuário
         string usuario;
         do
         {
            Console.Write("Usuário: ");
            usuario = Geral.RetornaString(Console.ReadLine());

            if (usuario == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (usuario == "");

         // Senha
         string senha;
         do
         {
            Console.Write("Senha: ");
            senha = Password();

            if (senha == "")
               Console.WriteLine("**Digite uma senha**");
         } while (senha == "");

         if (UsuarioRepositorio.GetLogin(usuario, senha))
            return usuario;


         Console.WriteLine("**Usuário e/ou Senha Incorreto(s)**");
         return "";
      }

      protected internal static void EsqueciSenha()
      {
         Console.WriteLine();

         // Nome
         string usuario;
         do
         {
            Console.Write("Usuário: ");
            usuario = Geral.RetornaString(Console.ReadLine());

            if (usuario == "")
               Console.WriteLine("**Campo vazio inválido**");
         } while (usuario == "");

         // Email
         string email;
         do
         {
            Console.Write("E-mail (ex@exemp.lo): ");
            email = Geral.Email(Console.ReadLine());

            if (email == "")
               Console.WriteLine("**Digite corretamente o e-mail**");
         } while (email == "");


         UsuarioRepositorio.LostPass(usuario, email);

      }

   }
}