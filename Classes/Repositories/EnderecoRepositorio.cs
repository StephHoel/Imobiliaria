using System.Collections.Generic;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class EnderecoRepositorio : IRepositorio<Endereco>
    {
        private readonly List<Endereco> listaEndereco = new();
        public void Atualiza(int id, Endereco objeto, string objeto2)
        {
            listaEndereco[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaEndereco[id].Excluir();
        }

        public void Insere(Endereco objeto)
        {
            listaEndereco.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto, "");
        }

        public List<Endereco> Lista()
        {
            return listaEndereco;
        }

        public int ProximoId()
        {
            return listaEndereco.Count;
            // return Arquivo.ProximoId();
        }

        public Endereco RetornaPorId(int id)
        {
            return listaEndereco[id];
        }

      public void Insere(Endereco entidade, string entidade2)
      {
         throw new System.NotImplementedException();
      }
   }
}