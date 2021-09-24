namespace Imobiliaria.Classes
{
    public class Telefone
    {
        private long Cpf { get; set; }
        private int Cod { get; set; }
        private int Numero { get; set; }
        private bool Whatsapp { get; set; }
        private bool Recado { get; set; }
        private bool Excluido { get; set; }

        public Telefone(long cpf, int cod, int numero, bool whatsapp, bool recado, bool excluido = false)
        {
            this.Cpf = cpf;
            this.Cod = cod;
            this.Numero = numero;
            this.Whatsapp = whatsapp;
            this.Recado = recado;
            this.Excluido = excluido;
        }

        public long RetornaCpf()
        {
            return this.Cpf;
        }
        public int RetornaCod()
        {
            return this.Cod;
        }
        public int RetornaNumero()
        {
            return this.Numero;
        }
        public bool RetornaWhatsapp()
        {
            return this.Whatsapp;
        }
        public bool RetornaRecado()
        {
            return this.Recado;
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