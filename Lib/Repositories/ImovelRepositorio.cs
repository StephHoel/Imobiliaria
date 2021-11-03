using System;
using System.Collections.Generic;
using System.IO;
using Lib.Classes;
using Lib.Interfaces;
using Lib.Methods;

namespace Lib.Repositorio
{
   public class ImovelRepositorio : IRepositorio<Imovel>
   {
      readonly static string path = "Databases/imovel.db";
      private static readonly List<Imovel> lista = new();
      public void Atualiza(int id, Imovel objeto)
      {
         lista[id] = objeto;
         string[] list = Array.Empty<string>();
         foreach (var l in lista)
         {
            list[l.RetornaId() - 1] = $"{l.RetornaId()}|{l.RetornaCpfProprietario()}|{l.RetornaSituacao()}|{l.RetornaCep()}|{l.RetornaLogradouro()}|{l.RetornaNumero()}|{l.RetornaComplemento()}|{l.RetornaBairro()}|{l.RetornaCidade()}|{l.RetornaEstado()}|{l.RetornaPais()}|{l.RetornaExcluido()}";
         }
         DB.Atualizar(list, path);

         LogRepositorio.Log($"{DateTime.Now}|Atualização de Imovel id {id}");
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
         Atualiza(id, lista[id]);

         LogRepositorio.Log($"{DateTime.Now}|Exclusão de Imóvel id {id}");
      }

      public void Insere(Imovel objeto1, string objeto2)
      {
         lista.Add(objeto1);
         DB.Escrever(objeto2, path);

         LogRepositorio.Log($"{DateTime.Now}|Inserção de Imóvel id {lista.Count - 1}");
      }

      public static List<Imovel> Lista()
      {
         if (lista.Count == 0)
         {
            Carrega();
         }

         LogRepositorio.Log($"{DateTime.Now}|Carregamento da lista Imóvel");

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

      public Imovel RetornaPorId(int id)
      {
         return lista[id];
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

               Imovel imovel = new(int.Parse(l[0]), Encriptografia.Decrypt(l[1]), l[2], l[3], l[4], int.Parse(l[5]), l[6], l[7], l[8], l[9], l[10], bool.Parse(l[11]));
               lista.Add(imovel);
            }
         }
      }
   }
}