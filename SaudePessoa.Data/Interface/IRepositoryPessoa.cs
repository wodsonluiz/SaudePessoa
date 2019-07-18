using SaudePessoa.Data.Entities;
using System.Collections.Generic;

namespace SaudePessoa.Data.Interface
{
    public interface IRepositoryPessoa
    {
        IEnumerable<Pessoa> GetAll(string _connection);
        Pessoa GetById(int id, string _connection);
        bool Insert(Pessoa pessoa, string _connection);
        bool Update(Pessoa pessoa, string _connection);
        bool Delete(int id, string _connection);
    }
}