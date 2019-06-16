using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SaudePessoa.Data.Entities;

namespace SaudePessoa.Data.Interface
{
    public interface IRepositoryPessoa
    {
        IEnumerable<Pessoa> GetAll(string _connection);
        Pessoa GetById(int id, string _connection);
        void Insert(Pessoa pessoa, string _connection);
        bool Update(Pessoa pessoa, string _connection);
        bool Delete(int id, string _connection);
    }
}