using System;
using System.Collections.Generic;
using System.IO;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;
using Imobiliaria.Methods;

namespace Imobiliaria.Classes
{
   public class UsuarioRepositorio : IRepositorio<Usuario>
   {
      static readonly string path = "DataBase/Usuario.db";
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
      public void Atualiza(int id, Usuario objeto, List<Usuario> objeto2)
      {
         lista[id] = objeto;
      }

      public void Exclui(int id)
      {
         lista[id].Excluir();
      }

      public void Insere(Usuario objeto, string objeto2)
      {
         lista.Add(objeto);
         DB.Escrever(objeto2, path);
      }

      public static List<Usuario> Lista()
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

      public Usuario RetornaPorId(int id)
      {
         return lista[id];
      }
      public static Boolean GetLogin(string user, string pass)
      {
         foreach (var usu in lista)
         {
            if (user == usu.RetornaNome() && pass == usu.RetornaSenha())
            {
               return true;
            }
         }
         return false;

      }
      public static void LostPass(string user, string email)
      {
         foreach (var usu in lista)
         {
            if (user == usu.RetornaNome() && email == usu.RetornaEmail())
            {
               // informar nova senha
               Console.Write("Nova Senha: ");
               var pass = Encriptografia.Password();

               Usuario u = new(usu.RetornaId(), usu.RetornaNome(), usu.RetornaEmail(), pass, usu.RetornaExcluido());

               // atualizar lista e banco
               lista[usu.RetornaId() - 1] = u;

               string[] person = new string[lista.Count];
               foreach (var usuario1 in lista)
               {
                  person[usuario1.RetornaId() - 1] = $"{usuario1.RetornaId()}|{usuario1.RetornaNome()}|{usuario1.RetornaEmail()}|{usuario1.RetornaSenha()}|{usuario1.RetornaExcluido()}";
               }

               DB.Atualizar(person, path);

               Console.WriteLine("Senha Alterada com Sucesso");
               break;
            }
            else
               Console.WriteLine("Usuário e/ou Email Incorreto");
         }
      }

   }
}