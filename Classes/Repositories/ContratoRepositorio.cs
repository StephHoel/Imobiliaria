using System.Collections.Generic;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class ContratoRepositorio : IRepositorio<Contrato>
    {
        private readonly List<Contrato> listaContrato = new();
        public void Atualiza(int id, Contrato objeto)
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
            Arquivo.Escrever(objeto);
        }

        public List<Contrato> Lista()
        {
            return listaContrato;
        }

        public int ProximoId()
        {
            return listaContrato.Count;
            // return Arquivo.ProximoId();
        }

        public Contrato RetornaPorId(int id)
        {
            return listaContrato[id];
        }
    }
}