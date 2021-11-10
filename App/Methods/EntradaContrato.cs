using System;
using System.Collections.Generic;
using Lib.Repositorio;

namespace App.Methods
{
   public class EntradaContrato
   {
      static readonly ContratoRepositorio repositorio = new();

      public static void Atualizar(List<Lib.Classes.Contrato> list)
      {

      }
      public static void Excluir(List<Lib.Classes.Contrato> list)
      {

      }
      public static void Listar(List<Lib.Classes.Contrato> objeto)
      {
         Console.WriteLine("=====================");
         Console.WriteLine("**Listando Contratos**");
         Console.WriteLine("=====================");

         Output.Vazio(objeto.Count);
         foreach (var i in objeto)
         {
            if (!i.RetornaExcluido())
            {
               Console.WriteLine();
               Console.WriteLine($"ID do Contrato: {i.RetornaId()}");

            }
         }
         Console.WriteLine();
         Console.WriteLine("=====================");
         Console.WriteLine();
      }

      public static void Novo()
      {

      }
   }
}