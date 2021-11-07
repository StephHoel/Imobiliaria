using System;
using System.Collections.Generic;
using System.IO;
using Lib.Classes;
using Lib.Interfaces;
using Lib.Methods;

namespace Lib.Repositorio
{
   public class PessoaRepositorio : IRepositorio<Pessoa>
   {
      static readonly string path = "../Lib/Databases/pessoa.db";
      static readonly List<Pessoa> lista = new();

      public void Atualiza(int id, Pessoa objeto)
      {
         lista[id] = objeto;
         string[] list = Array.Empty<string>();
         foreach (var l in lista)
         {
            list[l.RetornaId() - 1] = $"{l.RetornaId()}|{l.RetornaCpf()}|{l.RetornaNome()}|{l.RetornaRg()}|{l.RetornaOrgaoUF()}|{l.RetornaDataNasc()}|{l.RetornaNaturalidade()}|{l.RetornaNacionalidade()}|{l.RetornaPai()}|{l.RetornaMae()}|{l.RetornaEstadoCivil()}|{l.RetornaFichaRapida()}|{l.RetornaEmail()}|{l.RetornaExcluido()}";
         }
         DB.Atualizar(list, path);

         LogRepositorio.Log($"{DateTime.Now}|Atualização de Pessoa id {id}");
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
         Atualiza(id, lista[id]);

         LogRepositorio.Log($"{DateTime.Now}|Exclusão de Pessoa id {id}");
      }

      public void Insere(Pessoa objeto1, string objeto2)
      {
         lista.Add(objeto1);
         DB.Escrever(objeto2, path);

         LogRepositorio.Log($"{DateTime.Now}|Inserção de Pessoa id {lista.Count - 1}");
      }

      public static List<Pessoa> Lista()
      {
         if (lista.Count == 0)
         {
            Carrega();
         }

         LogRepositorio.Log($"{DateTime.Now}|Carregamento da lista Pessoa");

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
         string[] readEndereco = File.ReadAllLines(path);
         if (readEndereco.Length != 0)
         {
            foreach (string line in readEndereco)
            {
               string[] l = Output.Split(line);

               string cpf = Encriptografia.Decrypt(l[1]);
               string rg = Encriptografia.Decrypt(l[3]);

               Pessoa usu = new(int.Parse(l[0]), cpf, l[2], rg, l[4], l[5], l[6], l[7], l[8], l[9], l[10], l[11], l[12]);
               lista.Add(usu);
            }
         }
      }

      public Pessoa RetornaPorId(int id)
      {
         return lista[id];
      }
   }
}