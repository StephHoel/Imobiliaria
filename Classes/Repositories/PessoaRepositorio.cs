using System.Collections.Generic;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        private readonly List<Pessoa> listaPessoa = new();
        public void Atualiza(int id, Pessoa objeto)
        {
            listaPessoa[id] = objeto; 
        }

        public void Exclui(int id)
        {
            listaPessoa[id].Excluir();
        }

        public void Insere(Pessoa objeto)
        {
            listaPessoa.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto);
        }

        public List<Pessoa> Lista()
        {
            return listaPessoa;
        }

        public int ProximoId()
        {
            return listaPessoa.Count;
            // return Arquivo.ProximoId();
        }

        public Pessoa RetornaPorId(int id)
        {
            return listaPessoa[id];
        }
    }
}