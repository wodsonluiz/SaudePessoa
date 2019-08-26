namespace SaudePessoa.Data.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public int Id_Pessoa { get; private set; }
        public string email { get; private set; }
        public string senha { get; private set; }
        public int status { get; private set; }

        public Usuario(int Id, int Id_Pessoa, string email, string senha, int status)
        {
            setUsuario(Id, Id_Pessoa, email, senha, status);
        }

        protected void setUsuario(int Id, int Id_Pessoa, string email, string senha, int status)
        {
            this.Id = Id;
            this.Id_Pessoa = Id_Pessoa;
            this.email = email;
            this.senha = senha;
            this.status = status;
        }
    }
}