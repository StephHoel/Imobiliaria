using System;

namespace Imobiliaria.Classes
{
    public class Contrato
    {
      private int IdContrato { get; set; }
      private long CpfLocatario { get; set; }
      private int IdImovel { get; set; }
      private DateTime DataInicio { get; set; }
      private DateTime DataFim { get; set; }
      private double ValorInicial { get; set; }
      private int Vencimento { get; set; }
      private DateTime? DataQuebra { get; set; }
      private DateTime? DataRenovacao { get; set; }
      private bool Finalizado { get; set; }
      private bool Excluido { get; set; }

      public Contrato(long cpfLocatario, int idImovel, DateTime dataInicio, DateTime dataFim, double valorInicial, int vencimento)
      {
         this.CpfLocatario = cpfLocatario; 
         this.IdImovel = idImovel;
         this.DataInicio = dataInicio;
         this.DataFim = dataFim;
         this.ValorInicial = valorInicial;
         this.Vencimento = vencimento;
         this.Finalizado = false;
         this.Excluido = false;

      }
      public int RetornaIdContrato()
      {
         return this.IdContrato;
      }
      public long RetornaCpfLocatario()
      {
         return this.CpfLocatario;
      }
      public int RetornaIdImovel()
      {
         return this.IdImovel;
      }
      public DateTime RetornaDataInicio()
      {
         return this.DataInicio;
      }
      public DateTime RetornaDataFim()
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
      public DateTime? RetornaDataQuebra()
      {
         return this.DataQuebra;
      }
      public DateTime? RetornaDataRenovacao()
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