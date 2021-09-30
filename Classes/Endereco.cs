namespace Imobiliaria.Classes
{
    public class Endereco : EnderecoBase
    {
      private string Cpf { get; set; }

      public Endereco(string cpf, int cep, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string pais, bool excluido = false)
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
         this.Excluido = excluido;
      }

      public string RetornaCpf()
      {
         return this.Cpf;
      }

    }
}