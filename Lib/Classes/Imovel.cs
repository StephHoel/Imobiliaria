namespace Lib.Classes
{
   public class Imovel : EnderecoBase
   {
      private int IdImovel { get; set; }
      private string CpfProprietario { get; set; }
      private string Situacao { get; set; }

      public Imovel(int idImovel, string cpfProprietario, string situacao, string cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais, bool excluido = false)
      {
         this.IdImovel = idImovel;
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

      public int RetornaId()
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

   }
}