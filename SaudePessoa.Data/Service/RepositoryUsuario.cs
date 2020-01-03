using Dapper;
using MySql.Data.MySqlClient;
using Polly;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
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

                    return true;
                }
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
                    UnicodeEncoding encoding = new UnicodeEncoding();
                    byte[] hashBytes;

                    using (HashAlgorithm has = SHA1.Create())
                    {
                        hashBytes = has.ComputeHash(encoding.GetBytes(usuario.senha));

                        StringBuilder hashValueSenha = new StringBuilder(hashBytes.Length * 2);

                        foreach (byte b in hashBytes)
                        {
                            hashValueSenha.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                        }

                        var parametros = new DynamicParameters();
                        parametros.Add("Id_Pessoa", usuario.Id_Pessoa, DbType.Int32);
                        parametros.Add("Email", usuario.email, DbType.String);
                        parametros.Add("Senha", hashValueSenha.ToString(), DbType.String);
                        parametros.Add("Status", usuario.status, DbType.Int32);
                        parametros.Add("DataRegistro", DateTime.Now, DbType.DateTime);

                        conexao.Open();

                        await Policy.Handle<Exception>()
                        .WaitAndRetryAsync(2, i => TimeSpan.FromSeconds(2))
                        .ExecuteAsync(async () => await conexao.ExecuteAsync("Insert into Usuario(Id_Pessoa, Email, Senha, Status, DataRegistro)" +
                            "values(@Id_Pessoa, @Email, @Senha, @Status, @DataRegistro)", parametros));

                        return true;
                    }
                }
            }
            catch (Exception ex)
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
                    UnicodeEncoding encoding = new UnicodeEncoding();
                    byte[] hashBytes;

                    using (HashAlgorithm has = SHA1.Create())
                    {
                        hashBytes = has.ComputeHash(encoding.GetBytes(password));

                        StringBuilder hashValueSenha = new StringBuilder(hashBytes.Length * 2);

                        foreach (byte b in hashBytes)
                        {
                            hashValueSenha.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                        }

                        var parametros = new DynamicParameters();
                        parametros.Add("Email", email, DbType.String);
                        parametros.Add("Senha", hashValueSenha.ToString(), DbType.String);

                        conexao.Open();

                        return await Policy.Handle<Exception>()
                        .WaitAndRetryAsync(2, i => TimeSpan.FromSeconds(2))
                        .ExecuteAsync(async () => await conexao.QueryFirstOrDefaultAsync<Usuario>("Select * from Usuario where email = @Email and senha = @Senha",
                        parametros));
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
