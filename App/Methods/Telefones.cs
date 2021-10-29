using System;
using System.Collections.Generic;
using Imobiliaria.Classes;

namespace Imobiliaria
{
   public class Telefones
   {
      static readonly TelefoneRepositorio repositorio = new();
      static bool resultado = true;
      static bool novoNumero = false;

      protected internal static void NovoTelefone(string cpf)
      {
         int id = repositorio.ProximoId();

         if (id < 0)
         {
            Console.WriteLine("Erro no sistema, reinicie a aplicação");
            Console.ReadLine();
         }
         else
         {
            do
            {
               Console.WriteLine();
               Output.Titulo("Adicionando Número de Telefone");

               int cod = Codigo("DDD (apenas números): ");
               int numero = Numero("Número (8 digitos para fixo ou 9 dígitos para celular): ");
               bool whatsapp = Whatsapp("Esse número é Whatsapp (S/N)? ");
               bool recado = Recado("Esse número é apenas para recado (S/N)? ");


               Telefone telefone = new(id, cpf, cod, numero, whatsapp, recado);

               string telefone2 = $"{id}|{cpf}|{cod}|{numero}|{whatsapp}|{recado}|{false}";

               repositorio.Insere(telefone, telefone2);

               id = repositorio.ProximoId();
               novoNumero = NovoNumero();
            } while (novoNumero);
         }

      }

      internal static void AtualizaTelefone(string cpf, int id)
      {
         Console.WriteLine();
         Output.Titulo("Alterando Número de Telefone");

         int cod = Codigo("DDD (apenas números): ");
         int numero = Numero("Número (8 digitos para fixo ou 9 dígitos para celular): ");
         bool whatsapp = Whatsapp("Esse número é Whatsapp (S/N)? ");
         bool recado = Recado("Esse número é apenas para recado (S/N)? ");

         Telefone telefone = new(id, cpf, cod, numero, whatsapp, recado);

         // telefones.Add(telefone);

         novoNumero = NovoNumero();
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