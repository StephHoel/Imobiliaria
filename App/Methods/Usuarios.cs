using System;
using System.Collections.Generic;
using Imobiliaria.Classes;
using Imobiliaria.DataBase;
using Imobiliaria.Methods;

namespace Imobiliaria
{
   public class Usuarios
   {
      static readonly UsuarioRepositorio repositorio = new();

      protected internal static void NovoUsuario()
      {
         int id = repositorio.ProximoId();

         if (id < 0)
         {
            Console.WriteLine("Erro no sistema, reinicie a aplicação");
            Console.ReadLine();
         }
         else
         {
            string nome, email, senha;
            Console.WriteLine();
            Console.Write("Usuário: ");
            nome = Console.ReadLine();
            // Console.Write("Email: ");
            email = Input.Email();
            Console.Write("Senha: ");
            senha = Encriptografia.Password();

            Usuario user = new(id, nome, email, senha);
            string user2 = $"{id}|{nome}|{email}|{senha}|{false}";

            repositorio.Insere(user, user2);

            Console.WriteLine();
            Console.WriteLine("**Usuário cadastrado com sucesso**");
            Console.WriteLine();
         }

      }

      protected internal static string Login()
      {
         string usuario, senha;
         Console.WriteLine();
         usuario = Input.PedeString("Usuário: ");
         senha = Input.Senha();

         if (UsuarioRepositorio.GetLogin(usuario, senha))
         {
            return usuario;
         }

         Console.WriteLine("Usuário e/ou Senha Incorreto");
         return "";
      }


      protected internal static void EsqueciSenha()
      {
         string usuario, email;
         Console.WriteLine();
         Console.Write("Usuário: ");
         usuario = Console.ReadLine();
         email = Input.Email();

         UsuarioRepositorio.LostPass(usuario, email);

      }

   }
}