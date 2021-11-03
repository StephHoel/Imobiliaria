namespace Imobiliaria.Classes
{
   public class Pessoa
    {
        private int Id { get; set; }
        private string Cpf { get; set; }
        private string Nome { get; set; }
        private string Rg { get; set; }
        private string OrgaoUF { get; set; }
        private string DataNasc { get; set; }
        private string Nacionalidade { get; set; }
        private string Naturalidade { get; set; }
        private string Pai { get; set; }
        private string Mae { get; set; }
        private string EstadoCivil { get; set; }
        private string FichaRapida { get; set; }
        private string Email { get; set; }
        private bool Excluido { get; set; }

        public Pessoa(int id, string cpf, string nome, string rg, string orgaouf, string datanasc, string nacionalidade, string naturalidade, string pai, string mae, string estadoCivil, string fichaRapida, string email, bool excluido = false)
        {
            this.Id = id;
            this.Cpf = cpf;
            this.Nome = nome;
            this.Rg = rg;
            this.OrgaoUF = orgaouf;
            this.DataNasc = datanasc;
            this.Nacionalidade = nacionalidade;
            this.Naturalidade = naturalidade;
            this.Pai = pai;
            this.Mae = mae;
            this.EstadoCivil = estadoCivil;
            this.FichaRapida = fichaRapida;
            this.Email = email;
            this.Excluido = excluido;
        }

        public int RetornaId()
        {
            return this.Id;
        }
        public string RetornaCpf()
        {
            return this.Cpf;
        }
        public string RetornaNome()
        {
            return this.Nome;
        }
        public string RetornaRg()
        {
            return this.Rg;
        }
        public string RetornaOrgaoUF()
        {
            return this.OrgaoUF;
        }
        public string RetornaDataNasc()
        {
            return this.DataNasc;
        }
        public string RetornaNacionalidade()
        {
            return this.Nacionalidade;
        }
        public string RetornaNaturalidade()
        {
            return this.Naturalidade;
        }
        public string RetornaPai()
        {
            return this.Pai;
        }
        public string RetornaMae()
        {
            return this.Mae;
        }
        public string RetornaEstadoCivil()
        {
            return this.EstadoCivil;
        }
        public string RetornaFichaRapida()
        {
            return this.FichaRapida;
        }
        public string RetornaEmail()
        {
            return this.Email;
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