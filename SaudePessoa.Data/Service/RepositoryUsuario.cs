using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System;

namespace SaudePessoa.Data.Service
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public bool Desativar(string email, string _connection)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Usuario pessoa, string _connection)
        {
            throw new NotImplementedException();
        }

        public bool Logar(string email, string password, string _connection)
        {
            throw new NotImplementedException();
        }
    }
}
