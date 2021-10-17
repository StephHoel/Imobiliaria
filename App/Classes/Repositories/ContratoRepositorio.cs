using System.Collections.Generic;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class ContratoRepositorio : IRepositorio<Contrato>
   {
        readonly string path = "DataBase/contrato.db";
        private readonly List<Contrato> listaContrato = new();
        public void Atualiza(int id, Contrato objeto, List<Contrato> objeto2)
        {
            listaContrato[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaContrato[id].Excluir();
        }

        public void Insere(Contrato objeto)
        {
            listaContrato.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto, "");
        }

        public List<Contrato> Lista()
        {
            return listaContrato;
        }

        public int ProximoId()
        {
            int proximoLista = listaContrato.Count;
            int proximoDB = DataBase.DB.ProximoId(path);

            if (proximoLista == proximoDB)
            {
                return proximoDB;
            }
            else
            {
                return -1;
            }
        }

        public Contrato RetornaPorId(int id)
        {
            return listaContrato[id];
        }

      public void Insere(Contrato entidade, string entidade2)
      {
         throw new System.NotImplementedException();
      }

      private class DB
      {
      }
   }
}