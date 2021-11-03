namespace Lib.Classes
{
   public class Usuario
   {
      private int Id { get; set; }
      private string Nome { get; set; }
      private string Email { get; set; }
      private string Senha { get; set; }
      private bool Excluido { get; set; }

      public Usuario(int id, string nome, string email, string senha, bool excluido = false)
      {
         this.Id = id;
         this.Nome = nome;
         this.Email = email;
         this.Senha = senha;
         this.Excluido = excluido;
      }

      public int RetornaId()
      {
         return this.Id;
      }
      public string RetornaNome()
      {
         return this.Nome;
      }
      public string RetornaEmail()
      {
         return this.Email;
      }
      public string RetornaSenha()
      {
         return this.Senha;
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