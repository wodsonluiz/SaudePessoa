using SaudePessoa.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudePessoa.Data.Interface
{
    public interface IRepositoryPessoa
    {
        Task<IEnumerable<Pessoa>> GetAll(string _connection);
        Task<Pessoa> GetById(int id, string _connection);
        Task<bool> Insert(Pessoa pessoa, string _connection);
        Task<bool> Update(Pessoa pessoa, string _connection);
        Task<bool> Delete(int id, string _connection);
    }
}