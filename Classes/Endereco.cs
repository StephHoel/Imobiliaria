namespace Imobiliaria.Classes
{
    public class Endereco : EnderecoBase
    {
      private long Cpf { get; set; }

      public Endereco(long cpf, int cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais)
      {
         this.Cpf = cpf;
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

      public long RetornaCpf()
      {
         return this.Cpf;
      }

    }
}