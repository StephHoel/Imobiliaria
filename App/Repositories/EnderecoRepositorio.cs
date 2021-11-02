using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.Classes;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;
using Imobiliaria.Methods;

namespace Imobiliaria.Repositorio
{
   public class EnderecoRepositorio : IRepositorio<Endereco>
   {
      readonly static string path = "DataBase/endereco.db";
      private static readonly List<Endereco> lista = new();
      public void Atualiza(int id, Endereco objeto)
      {
         lista[id] = objeto;
         string[] list = Array.Empty<string>();
         foreach (var l in lista)
         {
            list[l.RetornaId() - 1] = $"{l.RetornaId()}|{l.RetornaCpf()}|{l.RetornaCep()}|{l.RetornaLogradouro()}|{l.RetornaNumero()}|{l.RetornaComplemento()}|{l.RetornaBairro()}|{l.RetornaCidade()}|{l.RetornaEstado()}|{l.RetornaPais()}|{l.RetornaExcluido()}";
         }
         DB.Atualizar(list, path);

         LogRepositorio.Log($"{DateTime.Now}|Atualização de Endereço id {id}");
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
         Atualiza(id, lista[id]);

         LogRepositorio.Log($"{DateTime.Now}|Exclusão de Endereço id {id}");
      }

      public void Insere(Endereco objeto, string objeto2)
      {
         lista.Add(objeto);
         DB.Escrever(objeto2, path);

         LogRepositorio.Log($"{DateTime.Now}|Inserção de Endereço id {lista.Count - 1}");
      }

      public static List<Endereco> Lista()
      {
         if (lista.Count == 0)
         {
            Carrega();
         }

         LogRepositorio.Log($"{DateTime.Now}|Carregamento da lista Endereço");

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

               Endereco end = new(int.Parse(l[0]), Encriptografia.Decrypt(l[1]), l[2], l[3], int.Parse(l[4]), l[5], l[6], l[7], l[8], l[9], bool.Parse(l[10]));
               lista.Add(end);
            }
         }
      }

      public Endereco RetornaPorId(int id)
      {
         return lista[id];
      }
   }
}