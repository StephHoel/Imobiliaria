using System.Collections.Generic;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
   {
        readonly string path = "DataBase/Usuario.db";
        private readonly List<Usuario> listaUsuario = new();
        public void Atualiza(int id, Usuario objeto, List<Usuario> objeto2)
        {
            listaUsuario[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaUsuario[id].Excluir();
        }

        public void Insere(Usuario objeto)
        {
            listaUsuario.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto, "");
        }

        public List<Usuario> Lista()
        {
            return listaUsuario;
        }

        public int ProximoId()
        {
            int proximoLista = listaUsuario.Count;
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

        public Usuario RetornaPorId(int id)
        {
            return listaUsuario[id];
        }

      public void Insere(Usuario entidade, string entidade2)
      {
         throw new System.NotImplementedException();
      }
   }
}