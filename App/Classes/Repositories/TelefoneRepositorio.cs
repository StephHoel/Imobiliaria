using System.Collections.Generic;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class TelefoneRepositorio : IRepositorio<Telefone>
   {
        readonly string path = "DataBase/telefone.db";
        private readonly List<Telefone> lista = new();
        public void Atualiza(int id, Telefone objeto, List<Telefone> objeto2)
        {
            lista[id] = objeto;
        }

        public void Exclui(int id)
        {
            lista[id].Excluir();
        }

        public void Insere(Telefone objeto)
        {
            lista.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto, "");
        }

        public List<Telefone> Lista()
        {
            return lista;
        }

        public int ProximoId()
        {
            int proximoLista = lista.Count;
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

        public Telefone RetornaPorId(int id)
        {
            return lista[id];
        }

      public void Insere(Telefone entidade, string entidade2)
      {
         throw new System.NotImplementedException();
      }
   }
}