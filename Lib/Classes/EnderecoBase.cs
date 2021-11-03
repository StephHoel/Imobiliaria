namespace Lib.Classes
{
   public abstract class EnderecoBase
   {
      protected internal string Cep { get; set; }
      protected internal string Logradouro { get; set; }
      protected internal int Numero { get; set; }
      protected internal string Complemento { get; set; }
      protected internal string Bairro { get; set; }
      protected internal string Cidade { get; set; }
      protected internal string Estado { get; set; }
      protected internal string Pais { get; set; }
      protected internal bool Excluido { get; set; }

      public string RetornaCep()
      {
         return this.Cep;
      }
      public string RetornaLogradouro()
      {
         return this.Logradouro;
      }
      public int RetornaNumero()
      {
         return this.Numero;
      }
      public string RetornaComplemento()
      {
         return this.Complemento;
      }
      public string RetornaBairro()
      {
         return this.Bairro;
      }
      public string RetornaCidade()
      {
         return this.Cidade;
      }
      public string RetornaEstado()
      {
         return this.Estado;
      }
      public string RetornaPais()
      {
         return this.Pais;
      }
      public bool RetornaExcluido()
      {
         return this.Excluido;
      }
      public void Excluir()
      {
         this.Excluido = true;
      }
   }
}