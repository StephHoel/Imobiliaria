namespace Imobiliaria.Classes
{
    public class Usuario
    {
        private int IdTelefone { get; set; }
        private string Cpf { get; set; }
        private int Cod { get; set; }
        private int Numero { get; set; }
        private bool Whatsapp { get; set; }
        private bool Recado { get; set; }
        private bool Excluido { get; set; }

        public Usuario(int id, string cpf, int cod, int numero, bool whatsapp, bool recado, bool excluido = false)
        {
            this.IdTelefone = id;
            this.Cpf = cpf;
            this.Cod = cod;
            this.Numero = numero;
            this.Whatsapp = whatsapp;
            this.Recado = recado;
            this.Excluido = excluido;
        }

        public int RetornaId()
        {
            return this.IdTelefone;
        }
        public string RetornaCpf()
        {
            string cpf = this.Cpf;
            string novo = cpf[..3] + ".";
            novo += cpf.Substring(3, 3) + ".";
            novo += cpf.Substring(6, 3) + "-";
            novo += cpf.Substring(9, 2);
            return novo;
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