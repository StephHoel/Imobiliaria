using System;
using System.IO;

namespace Imobiliaria.DataBase
{
   public class DB
    {
        protected internal static void Escrever(string objeto, string path)
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

        protected internal static void Atualizar(string[] objeto, string path)
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

        protected internal static int ProximoId(string path)
        {
            string[] readText = File.ReadAllLines(path);
            return readText.Length;
        }

        //
    }
}
