using System.Collections.Generic;
using Imobiliaria.DataBase;
using Imobiliaria.Interfaces;

namespace Imobiliaria.Classes
{
    public class EnderecoRepositorio : IRepositorio<Endereco>
   {
        readonly string path = "DataBase/endereco.db";
        private readonly List<Endereco> listaEndereco = new();
        public void Atualiza(int id, Endereco objeto, List<Endereco> objeto2)
        {
            listaEndereco[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaEndereco[id].Excluir();
        }

        public void Insere(Endereco objeto, string objeto2)
        {
            listaEndereco.Add(objeto);
            DB.Escrever(objeto2, path);
        }

        public List<Endereco> Lista()
        {
            return listaEndereco;
        }

        public int ProximoId()
        {
            int proximoLista = listaEndereco.Count;
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
            return listaEndereco[id];
        }
   }
}