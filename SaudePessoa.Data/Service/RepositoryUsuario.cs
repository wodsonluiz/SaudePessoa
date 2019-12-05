using Dapper;
using MySql.Data.MySqlClient;
using Polly;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SaudePessoa.Data.Service
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public async Task<bool> Desativar(string email, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Email", email, DbType.String);

                    await Policy.Handle<Exception>()
                    .WaitAndRetryAsync(2, i => TimeSpan.FromSeconds(2))
                    .ExecuteAsync(async () => await conexao.ExecuteAsync("update Usuario set status = 2 where Email = @Email", parametros));
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Insert(Usuario usuario, string _connection)
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

                    await Policy.Handle<Exception>()
                    .WaitAndRetryAsync(2, i => TimeSpan.FromSeconds(2))
                    .ExecuteAsync(async () => await conexao.ExecuteAsync("Insert into Usuario(Id_Pessoa, Email, Senha, Status)" +
                         "values(@Id_Pessoa, @Email, @Senha, @Status)", parametros));

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Usuario> Logar(string email, string password, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Email", email, DbType.String);
                    parametros.Add("Senha", password, DbType.String);

                    return await Policy.Handle<Exception>()
                    .WaitAndRetryAsync(2, i => TimeSpan.FromSeconds(2))
                    .ExecuteAsync(async () => await conexao.QueryFirstOrDefaultAsync<Usuario>("Select * from Usuario where email = @Email and senha = @Senha", 
                    parametros));
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
