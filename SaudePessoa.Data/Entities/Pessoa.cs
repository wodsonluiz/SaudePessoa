using System;
using System.ComponentModel.DataAnnotations;

namespace SaudePessoa.Data.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome_Documento { get; set; }
        public string Nome_Social { get; set; }
        public int Sexo { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Situacao_Familiar { get; set; }
        public string Cor_Pele { get; set; }
        public string Etinia { get; set; }
        public string Religiao { get; set; }
        public string Nome_Mae { get; set; }
        public string Nome_Pai { get; set; }
        public string Nome_Conjugue { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
    }
}