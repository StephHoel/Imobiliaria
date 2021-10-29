using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;
using Imobiliaria.Methods;

namespace Imobiliaria.Classes
{
   public class PessoaRepositorio : IRepositorio<Pessoa>
   {
      static readonly string path = "DataBase/pessoa.db";
      private static readonly List<Pessoa> lista = new();

      public void Atualiza(int id, Pessoa objeto, List<Pessoa> objeto2)
      {
         lista[id] = objeto;
         string[] person = Array.Empty<string>();
         foreach (var pessoa in objeto2)
         {
            person[pessoa.RetornaId() - 1] = $"{pessoa.RetornaId()}|{pessoa.RetornaCpf()}|{pessoa.RetornaNome()}|{pessoa.RetornaRg()}|{pessoa.RetornaOrgaoUF()}|{pessoa.RetornaDataNasc()}|{pessoa.RetornaNaturalidade()}|{pessoa.RetornaNacionalidade()}|{pessoa.RetornaPai()}|{pessoa.RetornaMae()}|{pessoa.RetornaEstadoCivil()}|{pessoa.RetornaFichaRapida()}|{pessoa.RetornaEmail()}|{pessoa.RetornaExcluido()}";
         }
         DB.Atualizar(person, path);
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
         Atualiza(id, lista[id], lista);
      }

      public void Insere(Pessoa objeto1, string objeto2)
      {
         lista.Add(objeto1);
         DB.Escrever(objeto2, path);
      }

      public static List<Pessoa> Lista()
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