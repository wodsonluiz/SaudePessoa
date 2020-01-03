using System;

namespace SaudePessoa.Data.Entities
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome_Documento { get; private set; }
        public string Nome_Social { get; private set; }
        public int Sexo { get; private set; }
        public DateTime Data_Nascimento { get; private set; }
        public string Situacao_Familiar { get; private set; }
        public string Cor_Pele { get; private set; }
        public string Etinia { get; private set; }
        public string Religiao { get; private set; }
        public string Nome_Mae { get; private set; }
        public string Nome_Pai { get; private set; }
        public string Nome_Conjugue { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime Dt_Registro { get; set; }

        public Pessoa(int Id, string Nome_Documento, string Nome_Social, int Sexo, DateTime Data_Nascimento, string Situacao_Familiar, string Cor_Pele, string Etinia, string Religiao, 
            string Nome_Mae, string Nome_Pai, string Nome_Conjugue, string Cpf, string Rg, DateTime Dt_Registro)
        {
            SetPessoa(Id, Nome_Documento, Nome_Social, Sexo, Data_Nascimento, Situacao_Familiar, Cor_Pele, Etinia, Religiao, 
                Nome_Mae, Nome_Pai, Nome_Conjugue, Cpf, Rg, Dt_Registro);
        }

        protected void SetPessoa(int Id, string Nome_Documento, string Nome_Social, int Sexo, DateTime Data_Nascimento, string Situacao_Familiar, string Cor_Pele, string Etinia, string Religiao, 
            string Nome_Mae, string Nome_Pai, string Nome_Conjugue, string Cpf, string Rg, DateTime Dt_Registro)
        {
            this.Id = Id;
            this.Nome_Documento = Nome_Documento;
            this.Nome_Social = Nome_Social;
            this.Sexo = Sexo;
            this.Data_Nascimento = Data_Nascimento;
            this.Situacao_Familiar = Situacao_Familiar;
            this.Cor_Pele = Cor_Pele;
            this.Etinia = Etinia;
            this.Religiao = Religiao;
            this.Nome_Mae = Nome_Mae;
            this.Nome_Pai = Nome_Pai;
            this.Nome_Conjugue = Nome_Conjugue;
            this.Cpf = Cpf;
            this.Rg = Rg;
            this.Dt_Registro = Dt_Registro;
        }
    }
}