using System.Collections.Generic;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class ImovelRepositorio : IRepositorio<Imovel>
   {
        readonly static string path = "DataBase/imovel.db";
        private static readonly List<Imovel> lista = new();
        public void Atualiza(int id, Imovel objeto, List<Imovel> objeto2)
        {
            lista[id] = objeto;
        }

        public void Exclui(int id)
        {
            lista[id].Excluir();
        }

        public void Insere(Imovel objeto)
        {
            lista.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto, "");
        }

        public static List<Imovel> Lista()
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

        public Imovel RetornaPorId(int id)
        {
            return lista[id];
        }

      public void Insere(Imovel entidade, string entidade2)
      {
         throw new System.NotImplementedException();
      }
   }
}