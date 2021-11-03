using System;
using System.IO;

namespace Lib.Classes
{
   public class DB
   {
      public static void Escrever(string objeto, string path)
      {
         try
         {
            if (!File.Exists(path))
            {
               using StreamWriter sw = File.CreateText(path);
               sw.WriteLine(objeto);
            }
            else
            {
               using StreamWriter sw = File.AppendText(path);
               sw.WriteLine(objeto);
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Erro: " + e.Message);
         }
      }

      public static void Atualizar(string[] objeto, string path)
      {
         try
         {
            using StreamWriter sw = File.CreateText(path);
            foreach (var pessoa in objeto)
            {
               sw.WriteLine(pessoa);
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Erro: " + e.Message);
         }
      }

      public static int ProximoId(string path)
      {
         string[] readText = File.ReadAllLines(path);
         return readText.Length;
      }
   }
}
