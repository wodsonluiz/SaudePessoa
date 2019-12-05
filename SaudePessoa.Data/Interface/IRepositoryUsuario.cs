using System.Threading.Tasks;
using SaudePessoa.Data.Entities;

namespace SaudePessoa.Data.Interface
{
    public interface IRepositoryUsuario
    {
        Task<bool> Insert(Usuario usuario, string _connection);
        Task<Usuario> Logar(string email, string password, string _connection);
        Task<bool> Desativar(string email, string _connection);
    }
}
