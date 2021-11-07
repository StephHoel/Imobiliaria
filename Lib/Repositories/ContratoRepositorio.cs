using System;
using System.Collections.Generic;
using System.IO;
using Lib.Classes;
using Lib.Interfaces;
using Lib.Methods;

namespace Lib.Repositorio
{
   public class ContratoRepositorio : IRepositorio<Contrato>
   {
      readonly static string path = "../Lib/Databases/contrato.db";
      private static readonly List<Contrato> lista = new();
      public void Atualiza(int id, Contrato objeto)
      {
         lista[id] = objeto;
         string[] list = Array.Empty<string>();
         foreach (var l in lista)
         {
            list[l.RetornaId() - 1] = $"{l.RetornaId()}|{l.RetornaCpfLocatario()}|{l.RetornaIdImovel()}|{l.RetornaDataInicio()}|{l.RetornaDataFim()}|{l.RetornaValorInicial()}|{l.RetornaVencimento()}|{l.RetornaFinalizado()}|{l.RetornaExcluido()}";
         }
         DB.Atualizar(list, path);

         LogRepositorio.Log($"{DateTime.Now}|Atualização de Contrato id {id}");
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
         Atualiza(id, lista[id]);

         LogRepositorio.Log($"{DateTime.Now}|Exclusão de Contrato id {id}");
      }

      public void Insere(Contrato objeto1, string objeto2)
      {
         lista.Add(objeto1);
         DB.Escrever(objeto2, path);

         LogRepositorio.Log($"{DateTime.Now}|Inserção de Contrato id {lista.Count - 1}");
      }

      public static List<Contrato> Lista()
      {
         if (lista.Count == 0)
         {
            Carrega();
         }

         LogRepositorio.Log($"{DateTime.Now}|Carregamento da lista Contrato");

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

      public Contrato RetornaPorId(int id)
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

               Contrato contrato = new(int.Parse(l[0]), Encriptografia.Decrypt(l[1]), int.Parse(l[2]), l[3], l[4], double.Parse(l[5]), int.Parse(l[6]), bool.Parse(l[7]), bool.Parse(l[8]));
               lista.Add(contrato);
            }
         }
      }
   }
}