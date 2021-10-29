using System.Collections.Generic;
using System.IO;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;
using Imobiliaria.Methods;

namespace Imobiliaria.Classes
{
   public class TelefoneRepositorio : IRepositorio<Telefone>
   {
      readonly static string path = "DataBase/telefone.db";
      private static readonly List<Telefone> lista = new();
      public void Atualiza(int id, Telefone objeto, List<Telefone> objeto2)
      {
         lista[id] = objeto;
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
      }

      public static void Inserir(string objeto)
      {
         Arquivo.Escrever(objeto, "");
      }

      public static List<Telefone> Lista()
      {
         if (lista.Count == 0)
         {
            Carrega();
         }
         return lista;
      }

      public int ProximoId()
      {
         int proximoLista = lista.Count;
         int proximoDB = DB.ProximoId(path);

         if (proximoLista == proximoDB)
         {
            return proximoDB + 1;
         }
         else
         {
            Carrega();
            return ProximoId();
         }
      }

      private static void Carrega()
      {
         lista.Clear();
         string[] read = File.ReadAllLines(path);
         if (read.Length != 0)
         {
            foreach (string line in read)
            {
               string[] l = Output.Split(line);

               Telefone tel = new(int.Parse(l[0]), Encriptografia.Decrypt(l[1]), int.Parse(l[2]), int.Parse(l[3]), bool.Parse(l[4]), bool.Parse(l[5]), bool.Parse(l[6]));
               lista.Add(tel);
            }
         }
      }

      public Telefone RetornaPorId(int id)
      {
         return lista[id];
      }

      public void Insere(Telefone objeto1, string objeto2)
      {
         lista.Add(objeto1);
         DB.Escrever(objeto2, path);
      }

   }
}