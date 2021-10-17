using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
   public class PessoaRepositorio : IRepositorio<Pessoa>
   {
      readonly string path = "DataBase/pessoa.db";
      private readonly List<Pessoa> listaPessoa = new();

      public void Atualiza(int id, Pessoa objeto, List<Pessoa> objeto2)
      {
         listaPessoa[id] = objeto;
         string[] person = Array.Empty<string>();
         foreach (var pessoa in objeto2)
         {
            person[pessoa.RetornaId() - 1] = $"{pessoa.RetornaId()}|{pessoa.RetornaCpf()}|{pessoa.RetornaNome()}|{pessoa.RetornaRg()}|{pessoa.RetornaOrgaoUF()}|{pessoa.RetornaDataNasc()}|{pessoa.RetornaNaturalidade()}|{pessoa.RetornaNacionalidade()}|{pessoa.RetornaPai()}|{pessoa.RetornaMae()}|{pessoa.RetornaEstadoCivil()}|{pessoa.RetornaFichaRapida()}|{pessoa.RetornaEmail()}|{pessoa.RetornaExcluido()}";
         }
         DB.Atualizar(person, path);
      }

      public void Exclui(int id)
      {
         listaPessoa[id].Excluir();
      }

      public void Insere(Pessoa objeto1, string objeto2)
      {
         listaPessoa.Add(objeto1);
         DB.Escrever(objeto2, path);
      }

      public List<Pessoa> Lista()
      {

         return listaPessoa;
      }

      public int ProximoId()
      {
         int proximoLista = listaPessoa.Count;
         int proximoDB = DB.ProximoId(path);

         if (proximoLista == proximoDB)
         {
            return proximoDB;
         }
         else
         {
            return -1;
         }
      }

      public Pessoa RetornaPorId(int id)
      {
         return listaPessoa[id];
      }
   }
}