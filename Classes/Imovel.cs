using System;

namespace Imobiliaria.Classes
{
    public class Imovel : EnderecoBase
    {
      private int IdImovel { get; set; }
      private string CpfProprietario { get; set; }
      private string Situacao { get; set; }

      public Imovel(string cpfProprietario, string situacao, int cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais, bool excluido = false)
      {
         this.IdImovel = ProximoId();
         this.CpfProprietario = cpfProprietario;
         this.Situacao = situacao;
         this.Cep = cep;
         this.Logradouro = logradouro;
         this.Numero = numero;
         this.Complemento = complemento;
         this.Bairro = bairro;
         this.Cidade = cidade;
         this.Estado = estado;
         this.Pais = pais;
         this.Excluido = excluido;
      }

      public int RetornaIdImovel()
      {
         return this.IdImovel;
      }
      public string RetornaCpfProprietario()
      {
         return this.CpfProprietario;
      }
      public string RetornaSituacao()
      {
         return this.Situacao;
      }

      public int ProximoId()
      {
         // Pegar tamanho da lista

         throw new NotImplementedException();

         // return 0;
      }

    }
}