using System.Collections.Generic;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class ImovelRepositorio : IRepositorio<Imovel>
    {
        private readonly List<Imovel> listaImovel = new();
        public void Atualiza(int id, Imovel objeto, string objeto2)
        {
            listaImovel[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaImovel[id].Excluir();
        }

        public void Insere(Imovel objeto)
        {
            listaImovel.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto, "");
        }

        public List<Imovel> Lista()
        {
            return listaImovel;
        }

        public int ProximoId()
        {
            return listaImovel.Count;
            // return Arquivo.ProximoId();
        }

        public Imovel RetornaPorId(int id)
        {
            return listaImovel[id];
        }

      public void Insere(Imovel entidade, string entidade2)
      {
         throw new System.NotImplementedException();
      }
   }
}