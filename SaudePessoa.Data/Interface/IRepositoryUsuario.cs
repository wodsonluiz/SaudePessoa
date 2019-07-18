using SaudePessoa.Data.Entities;

namespace SaudePessoa.Data.Interface
{
    public interface IRepositoryUsuario
    {
        bool Insert(Usuario usuario, string _connection);
        Usuario Logar(string email, string password, string _connection);
        bool Desativar(string email, string _connection);
    }
}
