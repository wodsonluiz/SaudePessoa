using System;

namespace SaudePessoa.Data.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public int Id_Pessoa { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public int status { get; private set; }
        public DateTime DataRegistro { get; set; }

        public Usuario(int Id, int Id_Pessoa, string email, string senha, int status, DateTime DataRegistro)
        {
            setUsuario(Id, Id_Pessoa, email, senha, status, DataRegistro);
        }

        protected void setUsuario(int Id, int Id_Pessoa, string email, string senha, int status, DateTime DataRegistro)
        {
            this.Id = Id;
            this.Id_Pessoa = Id_Pessoa;
            this.email = email;
            this.senha = senha;
            this.status = status;
            this.DataRegistro = DataRegistro;
        }
    }
}