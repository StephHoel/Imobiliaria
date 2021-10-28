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
      static bool resultado = true;

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
         Console.WriteLine();
         Console.Write("Usuário: ");
         Console.ReadLine();
         Console.Write("Senha: ");
         Console.ReadLine();
         return "";
      }

      internal static void AtualizaTelefone(string cpf, int id)
      {

      }

      private static int Codigo(string titulo)
      {
         int codigo;

         do
         {
            Console.Write(titulo);
            string codigoInput = Console.ReadLine();
            codigoInput = codigoInput.Length > 2 ? codigoInput.Substring(1, 3) : codigoInput;

            resultado = Int32.TryParse(codigoInput, out codigo);

            if (codigoInput.Length < 2) resultado = false;
            if (!resultado) Console.WriteLine("**Digite apenas 2 dígitos**");
         } while (!resultado);

         return codigo;
      }

      private static int Numero(string titulo)
      {
         int num;

         do
         {
            Console.Write(titulo);
            string numInput = Console.ReadLine();
            numInput = numInput.Length > 9 ? numInput[..9] : numInput;

            resultado = Int32.TryParse(numInput, out num);

            if (numInput.Length < 8) resultado = false;
            if (!resultado) Console.WriteLine("**Digite de 8 a 9 dígitos**");
         } while (!resultado);

         return num;
      }

      private static bool Whatsapp(string titulo)
      {
         bool whatsapp = false;

         do
         {
            Console.Write(titulo);
            string input = Console.ReadLine();
            input = input.Length > 1 ? input[..1] : input;

            if (input.ToUpper() == "S")
            {
               whatsapp = true;
            }

            if (input.Length != 1) resultado = false;
            if (!resultado) Console.WriteLine("**Digite S para sim ou N para não**");
         } while (!resultado);

         return whatsapp;
      }

      private static bool Recado(string titulo)
      {
         bool recado = false;

         do
         {
            Console.Write(titulo);
            string input = Console.ReadLine();
            input = input.Length > 1 ? input[..1] : input;

            if (input.ToUpper() == "S")
            {
               recado = true;
            }

            if (input.Length != 1) resultado = false;
            if (!resultado) Console.WriteLine("**Digite S para sim ou N para não**");
         } while (!resultado);

         return recado;
      }

      private static bool NovoNumero()
      {
         bool novo = false;

         do
         {
            Console.Write("Adicionar outro número (S/N)? ");
            string input = Console.ReadLine();
            input = input.Length > 1 ? input[..1] : input;

            if (input.ToUpper() == "S")
            {
               novo = true;
            }

            if (input.Length != 1) resultado = false;
            if (!resultado) Console.WriteLine("**Digite S para sim ou N para não**");
         } while (!resultado);

         return novo;
      }

   }
}