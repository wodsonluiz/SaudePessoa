using Dapper;
using MySql.Data.MySqlClient;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System;
using System.Data;

namespace SaudePessoa.Data.Service
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public bool Desativar(string email, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Email", email, DbType.String);

                    conexao.Execute("update Usuario set status = 2 where Email = @Email", parametros);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert(Usuario usuario, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Id_Pessoa", usuario.Id_Pessoa, DbType.Int32);
                    parametros.Add("Email", usuario.email, DbType.String);
                    parametros.Add("Senha", usuario.senha, DbType.String);
                    parametros.Add("Status", usuario.status, DbType.Int32);

                    conexao.Open();

                    conexao.Execute("Insert into Usuario(Id_Pessoa, Email, Senha, Status)" +
                         "values(@Id_Pessoa, @Email, @Senha, @Status)", parametros);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Usuario Logar(string email, string password, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Email", email, DbType.String);
                    parametros.Add("Senha", password, DbType.String);

                    return conexao.QueryFirstOrDefault<Usuario>("Select * from Usuario where email = @Email and senha = @Senha", parametros);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
