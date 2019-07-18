namespace SaudePessoa.Data.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Id_Pessoa { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }
    }
}