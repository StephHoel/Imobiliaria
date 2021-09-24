using System;

namespace Imobiliaria.Classes
{
    public class Imovel : EnderecoBase
    {
      private int IdImovel { get; set; }
      private long CpfProprietario { get; set; }

      public Imovel(long cpfProprietario, int cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais)
      {
         this.IdImovel = ProximoId();
         this.CpfProprietario = cpfProprietario;
         this.Cep = cep;
         this.Logradouro = logradouro;
         this.Numero = numero;
         this.Complemento = complemento;
         this.Bairro = bairro;
         this.Cidade = cidade;
         this.Estado = estado;
         this.Pais = pais;
         this.Excluido = false;
      }

      public long RetornaCpfProprietario()
      {
         return this.CpfProprietario;
      }

      public int ProximoId()
      {
         throw new NotImplementedException();
         // return 0;
      }

    }
}