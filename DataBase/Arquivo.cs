using System;
using System.IO;

namespace Imobiliaria
{
   public class Arquivo
    {
        protected internal const string path = "DataBase/sample.db";

        protected internal static void ListarTudo()
        {
            try
            {
                Output.Titulo("Lista de Séries");
                string[] readText = File.ReadAllLines(path);

                if(readText.Length != 0)
                {
                    foreach (string line in readText)
                    {
                        var lineSplit = Output.Split(line);
                        Console.WriteLine("#ID {0}: - {1} {2}", lineSplit[0], lineSplit[1], (bool.Parse(lineSplit[5]) ? "*Excluído*" : ""));
                    }
                }
                else NenhumaSerie();
            }
            catch(Exception e)
            {
                Erro(e.Message);
            }
        }

        protected internal static void ListarNaoExcluida()
        {
            try
            {
                Output.Titulo("Lista de Séries Cadastradas");
                string[] readText = File.ReadAllLines(path);

                if(readText.Length != 0)
                {
                    bool vazio = false;
                    foreach (string line in readText)
                    {
                        var lineSplit = line.Split('|');
                        if(!bool.Parse(lineSplit[5]))
                        {
                            Console.WriteLine("#ID {0}: - {1}", lineSplit[0], lineSplit[1]);
                            vazio = false;
                        }
                        else vazio = true;
                    }
                    if(vazio) NenhumaSerie();
                }
                else NenhumaSerie();
            }
            catch(Exception e)
            {
                Erro(e.Message);
            }
        }

        protected internal static void ListarExcluida()
        {
            Output.Titulo("Lista de Séries Excluídas");
            try
            {
                string[] readText = File.ReadAllLines(path);

                if(readText.Length != 0)
                {
                    bool vazio = true;
                    foreach (string line in readText)
                    {
                        var lineSplit = line.Split('|');
                        if(bool.Parse(lineSplit[5]))
                        {
                            Console.WriteLine("#ID {0}: - {1}", lineSplit[0], lineSplit[1]);
                            vazio = true;
                        }
                        else vazio = false;
                    }
                    if(!vazio) NenhumaSerie();
                }
                else NenhumaSerie();
            }
            catch(Exception e)
            {
                Erro(e.Message);
            }
        }

        protected internal static void Escrever(string texto)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using StreamWriter sw = File.CreateText(path);
                    sw.WriteLine(texto);
                }
                else
                {
                    using StreamWriter sw = File.AppendText(path);
                    sw.WriteLine(texto);
                }
            }
            catch(Exception e)
            {
                Erro(e.Message);
            }
        }

        protected internal static void Alterar(string[] novoTexto)
        {
            try
            {
                if (File.Exists(path))
				{
                    using StreamWriter sw = File.CreateText(path);
                    foreach (string line in novoTexto)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            catch(Exception e)
            {
                Erro(e.Message);
            }
        }

        protected internal static int ProximoId()
        {
            string[] readText = File.ReadAllLines(path);
            return readText.Length;
        }

        protected static void Erro(string erro)
        {
            Console.WriteLine("Erro: " + erro);
        }

        protected static void NenhumaSerie()
        {
            Console.WriteLine("Nenhuma série cadastrada");
        }
    }
}