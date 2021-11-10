using System;
using System.Collections.Generic;
using System.IO;
using App.Methods;
using Lib.Classes;
using Lib.Repositorio;

namespace Imobiliaria
{
   public class Program
   {

      static void Main()
      {
         LimparTela();
         Console.WriteLine("Bem vinde ao Cadastro de Clientes e Contratos");
         Console.WriteLine("Cadastre seus clientes e seus contratos e não perca mais nada!");
         Console.WriteLine();

         MenuLogin.Menu();

         Console.WriteLine();
         Console.WriteLine("Obrigada por utilizar nossos serviços. Até a próxima!");
         Console.WriteLine("Pressione ENTER para sair");
         Console.ReadLine();
      }

      private static void LimparTela()
      {
         try
         {
            Console.Clear();
         }
         catch (IOException)
         {
         }
      }
   }
}
