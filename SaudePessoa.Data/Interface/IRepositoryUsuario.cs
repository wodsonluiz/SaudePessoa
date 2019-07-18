using SaudePessoa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaudePessoa.Data.Interface
{
    public interface IRepositoryUsuario
    {
        bool Insert(Usuario pessoa, string _connection);
        bool Logar(string email, string password, string _connection);
        bool Desativar(string email, string _connection);
    }
}
