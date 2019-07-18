namespace SaudePessoa.Data.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Id_Pessoa { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int status { get; set; }
    }
}