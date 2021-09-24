using System;

namespace Imobiliaria.Classes
{
    public class Pessoa
    {
        private long Cpf { get; set; }
        private string Nome { get; set; }
        private long Rg { get; set; }
        private string OrgaoUF { get; set; }
        private DateTime DataNasc { get; set; }
        private string Nacionalidade { get; set; }
        private string Naturalidade { get; set; }
        private string Pai { get; set; }
        private string Mae { get; set; }
        private string Email { get; set; }
        private bool Excluido { get; set; }

        public Pessoa(long cpf, string nome, long rg, string orgaouf, DateTime datanasc, string nacionalidade, string naturalidade, string pai, string mae, string email)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Rg = rg;
            this.OrgaoUF = orgaouf;
            this.DataNasc = datanasc;
            this.Nacionalidade = nacionalidade;
            this.Naturalidade = naturalidade;
            this.Pai = pai;
            this.Mae = mae;
            this.Email = email;
            this.Excluido = false;

        }

        public long RetornaCpf()
        {
            return this.Cpf;
        }
        public string RetornaNome()
        {
            return this.Nome;
        }
        public long RetornaRg()
        {
            return this.Rg;
        }
        public string RetornaOrgaoUF()
        {
            return this.OrgaoUF;
        }
        public DateTime RetornaDataNasc()
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