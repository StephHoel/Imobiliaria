using System.Collections.Generic;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class TelefoneRepositorio : IRepositorio<Telefone>
    {
        private readonly List<Telefone> listaTelefone = new();
        public void Atualiza(int id, Telefone objeto)
        {
            listaTelefone[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaTelefone[id].Excluir();
        }

        public void Insere(Telefone objeto)
        {
            listaTelefone.Add(objeto);
        }

        public static void Inserir(string objeto)
        {
            Arquivo.Escrever(objeto);
        }

        public List<Telefone> Lista()
        {
            return listaTelefone;
        }

        public int ProximoId()
        {
            return listaTelefone.Count;
            // return Arquivo.ProximoId();
        }

        public Telefone RetornaPorId(int id)
        {
            return listaTelefone[id];
        }
    }
}