namespace Lib.Classes
{
   public class Contrato
   {
      private int IdContrato { get; set; }
      private string CpfLocatario { get; set; }
      private int IdImovel { get; set; }
      private string DataInicio { get; set; }
      private string DataFim { get; set; }
      private double ValorInicial { get; set; }
      private int Vencimento { get; set; }
      private string DataQuebra { get; set; }
      private string DataRenovacao { get; set; }
      private bool Finalizado { get; set; }
      private bool Excluido { get; set; }

      public Contrato(int idContrato, string cpfLocatario, int idImovel, string dataInicio, string dataFim, double valorInicial, int vencimento, bool finalizado = false, bool excluido = false)
      {
         this.IdContrato = idContrato;
         this.CpfLocatario = cpfLocatario;
         this.IdImovel = idImovel;
         this.DataInicio = dataInicio;
         this.DataFim = dataFim;
         this.ValorInicial = valorInicial;
         this.Vencimento = vencimento;
         this.Finalizado = finalizado;
         this.Excluido = excluido;

      }

      public int RetornaId()
      {
         return this.IdContrato;
      }
      public string RetornaCpfLocatario()
      {
         return this.CpfLocatario;
      }
      public int RetornaIdImovel()
      {
         return this.IdImovel;
      }
      public string RetornaDataInicio()
      {
         return this.DataInicio;
      }
      public string RetornaDataFim()
      {
         return this.DataFim;
      }
      public double RetornaValorInicial()
      {
         return this.ValorInicial;
      }
      public int RetornaVencimento()
      {
         return this.Vencimento;
      }
      public string RetornaDataQuebra()
      {
         return this.DataQuebra;
      }
      public string RetornaDataRenovacao()
      {
         return this.DataRenovacao;
      }
      public bool RetornaFinalizado()
      {
         return this.Finalizado;
      }
      public bool RetornaExcluido()
      {
         return this.Excluido;
      }
      public void Excluir()
      {
         this.Excluido = true;
      }
      public void Finalizar()
      {
         this.Finalizado = true;
      }
   }
}