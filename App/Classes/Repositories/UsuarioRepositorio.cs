using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
   public class UsuarioRepositorio : IRepositorio<Usuario>
   {
      static readonly string path = "DataBase/Usuario.db";
      private static readonly List<Usuario> listaUsuario = new();

      private static void Carrega()
      {
         listaUsuario.Clear();
         string[] readEndereco = File.ReadAllLines(path);
         if (readEndereco.Length != 0)
         {
            foreach (string line in readEndereco)
            {
               string[] l = Output.Split(line);

               Usuario usu = new(int.Parse(l[0]), l[1], l[2], l[3], bool.Parse(l[4]));
               listaUsuario.Add(usu);
            }
         }
      }
      public void Atualiza(int id, Usuario objeto, List<Usuario> objeto2)
      {
         listaUsuario[id] = objeto;
      }

      public void Exclui(int id)
      {
         listaUsuario[id].Excluir();
      }

      public void Insere(Usuario objeto, string objeto2)
      {
         listaUsuario.Add(objeto);
         DB.Escrever(objeto2, path);
      }

      public static List<Usuario> Lista()
      {
         if (listaUsuario.Count == 0)
         {
            Carrega();
         }
         return listaUsuario;
      }

      public int ProximoId()
      {
         int proximoLista = listaUsuario.Count;
         int proximoDB = DB.ProximoId(path);

         if (proximoLista == proximoDB)
         {
            return proximoDB+1;
         }
         else
         {
            Carrega();
            return ProximoId();
         }
      }

      public Usuario RetornaPorId(int id)
      {
         return listaUsuario[id];
      }
      public static Boolean GetLogin(string user, string pass)
      {
         foreach (var usu in listaUsuario)
         {
            if (user == usu.RetornaNome() && pass == usu.RetornaSenha())
            {
               return true;
            }
         }
         return false;

      }

   }
}