using System;

namespace SaudePessoa.Data.Entities
{
    public class Frase
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public int Estado { get; private set; }
        public string AutorFrase { get; private set; }
        public int IdPessoa { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public double RankLevel  { get; private set; }
        public string ExtraField { get; private set; }

        public Frase(int Id, string Descricao, int Estado, string AutorFrase, int IdPessoa, DateTime DataRegistro, double Rank, string ExtraField)
        {
            SetFrase(Id, Descricao, Estado, AutorFrase, IdPessoa, DataRegistro, Rank, ExtraField);
        }

        protected void SetFrase(int Id, string Descricao, int Estado, string AutorFrase, int IdPessoa, DateTime DataRegistro, double Rank, string ExtraField)
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Estado = Estado;
            this.AutorFrase = AutorFrase;
            this.IdPessoa = IdPessoa;
            this.DataRegistro = DataRegistro;
            this.RankLevel = Rank;
            this.ExtraField = ExtraField;
        }

    }
}