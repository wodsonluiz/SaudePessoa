using Dapper;
using MySql.Data.MySqlClient;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System.Collections.Generic;
using System.Data;

namespace SaudePessoa.Data.Service
{
    public class RepositoryPessoa : IRepositoryPessoa
    {
        public bool Delete(int Id, string _connection)
        {
            try
            {
                using(MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Nome_Documento", Id, DbType.String);

                    conexao.Execute("Delete Pessoa where Id = @Id", parametros);
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public Pessoa GetById(int id, string _connection)
        {
            try
            {
                using(MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("Id", id, DbType.Int32);

                    return conexao.QueryFirstOrDefault<Pessoa>("Select * from Pessoa where Id = @Id", parametros);
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public void Insert(Pessoa pessoa, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Nome_Documento", pessoa.Nome_Documento, DbType.String);
                    parametros.Add("Nome_Social", pessoa.Nome_Social, DbType.String);
                    parametros.Add("Sexo", pessoa.Sexo, DbType.Int32);
                    parametros.Add("Data_Nascimento", pessoa.Data_Nascimento, DbType.DateTime);
                    parametros.Add("Situacao_Familiar", pessoa.Situacao_Familiar, DbType.String);
                    parametros.Add("Cor_Pele", pessoa.Cor_Pele, DbType.String);
                    parametros.Add("Etinia", pessoa.Etinia, DbType.String);
                    parametros.Add("Religiao", pessoa.Religiao, DbType.String);
                    parametros.Add("Nome_Mae", pessoa.Nome_Mae, DbType.String);
                    parametros.Add("Nome_Pai", pessoa.Nome_Pai, DbType.String);
                    parametros.Add("Nome_Conjugue", pessoa.Nome_Conjugue, DbType.String);
                    parametros.Add("Cpf", pessoa.Cpf, DbType.String);
                    parametros.Add("Rg", pessoa.Rg, DbType.String);

                    conexao.Open();

                    conexao.Execute("Insert into Pessoa(Nome_Documento,Nome_Social,Sexo,Data_Nascimento,Situacao_Familiar,Cor_Pele,Etinia,Religiao,Nome_Mae,Nome_Pai,Nome_Conjugue,Cpf,Rg)" +
                         "values(@Nome_Documento, @Nome_Social, @Sexo, @Data_Nascimento, @Situacao_Familiar, @Cor_Pele, @Etinia, @Religiao, @Nome_Mae, @Nome_Pai, @Nome_Conjugue, @Cpf, @Rg)", parametros);
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public bool Update(Pessoa pessoa, string _connection)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("Nome_Documento", pessoa.Nome_Documento, DbType.String);
                    parametros.Add("Nome_Social", pessoa.Nome_Social, DbType.String);
                    parametros.Add("Data_Nascimento", pessoa.Data_Nascimento, DbType.DateTime);
                    parametros.Add("Cpf", pessoa.Situacao_Familiar, DbType.String);
                    parametros.Add("Rg", pessoa.Sexo, DbType.String);
                    parametros.Add("Id", pessoa.Sexo, DbType.Int32);
                   
                    conexao.Execute("Update Pessoa set Nome_Documento = @Nome_Documento, Nome_Social = @Nome_Social, Data_Nascimento = @Data_Nascimento, Rg = @Rg, Cpf = @Cpf where Id = @Id", parametros);
                };
            }
            catch (System.Exception)
            {
                return false;
            }
             return true;
        }
        IEnumerable<Pessoa> IRepositoryPessoa.GetAll(string _connection)
        {
           try
            {
                using(MySqlConnection conexao = new MySqlConnection(_connection))
                {
                    return conexao.Query<Pessoa>("Select * from Pessoa");
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}