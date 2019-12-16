using SaudePessoa.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudePessoa.Data.Interface
{
    public interface IRepositoryFrase
    {
        Task<IEnumerable<Frase>> GetAllFrases(string _connection);
        Task<Frase> GetFrases(string extraField, string _connection);
        Task<bool> Delete(int id, string _connection);
        Task<bool> Update(Frase frase, string _connection);
        Task<bool> Insert(Frase frase, string _connection);
    }
}
