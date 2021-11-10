using System;
using System.Collections.Generic;
using System.IO;
using Lib.Classes;
using Lib.Interfaces;
using Lib.Methods;

namespace Lib.Repositorio
{
   public class UsuarioRepositorio : IRepositorio<Usuario>
   {
      static readonly string path = "../Lib/Databases/usuario.db";
      private static readonly List<Usuario> lista = new();

      private static void Carrega()
      {
         lista.Clear();
         string[] readEndereco = File.ReadAllLines(path);
         if (readEndereco.Length != 0)
         {
            foreach (string line in readEndereco)
            {
               string[] l = Output.Split(line);

               Usuario usu = new(int.Parse(l[0]), l[1], l[2], l[3], bool.Parse(l[4]));
               lista.Add(usu);
            }
         }
      }
      public void Atualiza(int id, Usuario objeto)
      {
         lista[id] = objeto;
         string[] list = Array.Empty<string>();
         foreach (var l in lista)
         {
            list[l.RetornaId() - 1] = $"{l.RetornaId()}|{l.RetornaNome()}|{l.RetornaEmail()}|{l.RetornaSenha()}|{l.RetornaExcluido()}";
         }
         DB.Atualizar(list, path);

         LogRepositorio.Log($"{DateTime.Now}|Atualização de Usuário id {id}");
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
         Atualiza(id, lista[id]);

         LogRepositorio.Log($"{DateTime.Now}|Exclusão de Usuário id {id}");
      }

      public void Insere(Usuario objeto, string objeto2)
      {
         lista.Add(objeto);
         DB.Escrever(objeto2, path);

         LogRepositorio.Log($"{DateTime.Now}|Inserção de Usuário id {lista.Count - 1}");
      }

      public static List<Usuario> Lista()
      {
         if (lista.Count == 0)
         {
            Carrega();
         }

         LogRepositorio.Log($"{DateTime.Now}|Carregamento da lista Usuário");

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

      public Usuario RetornaPorId(int id)
      {
         return lista[id];
      }
      public static bool GetLogin(string user, string pass)
      {
         Carrega();
         foreach (var usu in lista)
         {
            if (user == usu.RetornaNome()
             && pass == usu.RetornaSenha()
             && usu.RetornaExcluido() == false)
            {
               LogRepositorio.Log($"{DateTime.Now}|Login de {usu.RetornaNome()}");

               return true;
            }
         }
         return false;

      }
      public static void LostPass(string user, string email)
      {
         bool passAltered = false;
         foreach (var usu in lista)
         {
            if (user == usu.RetornaNome() && email == usu.RetornaEmail())
            {
               // informar nova senha
               // Console.Write("Nova Senha: ");
               // var pass = Input.Senha("Nova Senha");

               // Usuario u = new(usu.RetornaId(), usu.RetornaNome(), usu.RetornaEmail(), pass, usu.RetornaExcluido());

               // atualizar lista e banco
               // lista[usu.RetornaId() - 1] = u;

               string[] list = new string[lista.Count];
               foreach (var usuario1 in lista)
               {
                  list[usuario1.RetornaId() - 1] = $"{usuario1.RetornaId()}|{usuario1.RetornaNome()}|{usuario1.RetornaEmail()}|{usuario1.RetornaSenha()}|{usuario1.RetornaExcluido()}";
               }

               DB.Atualizar(list, path);

               Console.WriteLine("Senha Alterada com Sucesso");
               passAltered = true;
               break;
            }
         }
         if (!passAltered)
            Console.WriteLine("Usuário e/ou Email Incorreto");
      }

   }
}