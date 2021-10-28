using System.Collections.Generic;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class EnderecoRepositorio : IRepositorio<Endereco>
   {
        readonly string path = "DataBase/endereco.db";
        private readonly List<Endereco> lista = new();
        public void Atualiza(int id, Endereco objeto, List<Endereco> objeto2)
        {
            lista[id] = objeto;
        }

        public void Exclui(int id)
        {
            lista[id].Excluir();
        }

        public void Insere(Endereco objeto, string objeto2)
        {
            lista.Add(objeto);
            DB.Escrever(objeto2, path);
        }

        public List<Endereco> Lista()
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

        public Endereco RetornaPorId(int id)
        {
            return lista[id];
        }
   }
}