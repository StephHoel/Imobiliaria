using System;
using System.Collections.Generic;
using Lib.Classes;
using Lib.Methods;
using Lib.Repositorio;

namespace App.Methods
{
   public class EntradaTelefone
   {
      static readonly TelefoneRepositorio repositorio = new();

      public static void Atualizar(List<Lib.Classes.Telefone> list)
      {

      }
      public static void Excluir(List<Lib.Classes.Telefone> list)
      {

      }

      public static void Novo(string cpf)
      {
         int id = repositorio.ProximoId();
         string novo;

         do
         {
            Console.WriteLine();
            Console.WriteLine("**Adicionando Número de Telefone**");

            // Código do Telefone
            string cod;
            do
            {
               Console.Write("DDD (apenas números): ");
               cod = MTelefone.Codigo(Console.ReadLine());

               if (cod == "")
                  Console.WriteLine("**Digite apenas 2 dígitos**");
            } while (cod == "");

            // Número do Telefone
            string num;
            do
            {
               Console.Write("Número (8 digitos para fixo ou 9 dígitos para celular): ");
               num = MTelefone.Numero(Console.ReadLine());

               if (num == "")
                  Console.WriteLine("**Digite de 8 a 9 dígitos**");
            } while (num == "");

            // Whatsapp
            string whatsapp;
            do
            {
               Console.Write("Esse número é Whatsapp (S/N)? ");
               whatsapp = Geral.SimOuNao(Console.ReadLine());

               if (whatsapp == "")
                  Console.WriteLine("**Digite S para sim ou N para não**");
            } while (whatsapp == "");

            // Recado
            string recado;
            do
            {
               Console.Write("Esse número é apenas para recado (S/N)? ");
               recado = Geral.SimOuNao(Console.ReadLine());

               if (recado == "")
                  Console.WriteLine("**Digite S para sim ou N para não**");
            } while (recado == "");

            Telefone telefone = new(id, cpf, int.Parse(cod), int.Parse(num), bool.Parse(whatsapp), bool.Parse(recado));

            string telefone2 = $"{id}|{cpf}|{cod}|{num}|{whatsapp}|{recado}|{false}";

            repositorio.Insere(telefone, telefone2);

            id = repositorio.ProximoId();

            // Novo Número?
            do
            {
               Console.Write("Adicionar outro número (S/N)? ");
               novo = Geral.SimOuNao(Console.ReadLine());

               if (novo == "")
                  Console.WriteLine("**Digite S para sim ou N para não**");
            } while (novo == "");

         } while (novo == "S");
      }


/*
      protected internal static void AtualizaTelefone(string cpf, int id)
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
 */
   }
}