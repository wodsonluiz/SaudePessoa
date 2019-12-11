using Dapper;
using MySql.Data.MySqlClient;
using Polly;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SaudePessoa.Data.Service
{
    public class RepositoryFrase : IRepositoryFrase
    {
        public async Task<bool> Delete(int id, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Id", id, DbType.String);

                    await Policy.Handle<Exception>()
                        .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2))
                        .ExecuteAsync(async () => await conexao.ExecuteAsync("Delete Frase where Id = @Id", parametros));

                    GC.SuppressFinalize(this);

                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Frase>> GetAllFrases(string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    GC.SuppressFinalize(this);

                    return await Policy.Handle<Exception>()
                        .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2))
                        .ExecuteAsync(async () => await conexao.QueryAsync<Frase>("Select * from Frase"));
                }
            }
            catch (Exception)
            {

                throw;
            }       
        }

        public async Task<Frase> GetFrases(string extraField, string _connection)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(Frase frase, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Id_Pessoa", frase.IdPessoa, DbType.Int32);
                    parametros.Add("Descricao", frase.Descricao, DbType.String);
                    parametros.Add("Estado", frase.Estado, DbType.Int32);
                    parametros.Add("AutorFrase", frase.AutorFrase, DbType.String);
                    parametros.Add("DataRegistro", frase.DataRegistro, DbType.DateTime);
                    parametros.Add("RankLevel", frase.RankLevel, DbType.Double);
                    parametros.Add("ExtraField", frase.ExtraField, DbType.String);

                    conexao.Open();

                    await Policy.Handle<Exception>()
                        .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2))
                        .ExecuteAsync(async () => await conexao.ExecuteAsync("Insert into Frase(Id_Pessoa, Descricao, Estado, AutorFrase, DataRegistro, RankLevel, ExtraField)" +
                         "values(@Id_Pessoa, @Descricao, @Estado, @AutorFrase, @DataRegistro, @RankLevel, @ExtraField)", parametros));

                    GC.SuppressFinalize(this);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Frase frase, string _connection)
        {
            throw new NotImplementedException();
        }
    }
}
