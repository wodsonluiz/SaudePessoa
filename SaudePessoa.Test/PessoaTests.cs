using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using SaudePessoa.Data.Service;
using System;
using Xunit;

namespace SaudePessoa.Test
{
    public class PessoaTests
    {
        public PessoaTests()
        {

        }

        [Fact]
        public void TestGetAll()
        {
            try
            {
                //Criação cenario
                IRepositoryPessoa repositoryPessoa = new RepositoryPessoa();
                var result = repositoryPessoa.GetAll("Server=localhost;Port=3306;Database=desenv_teste;Uid=root;Pwd=admin123;");

                //Efetuar Teste
                if (result != null)
                    Assert.True(true, "GelAll Sucesso");
                else
                    Assert.False(false, "GelAll Falid");
            }
            catch (System.Exception ex)
            {
                Assert.False(false, "GelAll" + ex.Message);
            }
        }

        [Fact]
        public void TesGetById()
        {
            try
            {
                //Criação cenario
                IRepositoryPessoa repositoryPessoa = new RepositoryPessoa();
                var result = repositoryPessoa.GetById(1, "Server=localhost;Port=3306;Database=desenv_teste;Uid=root;Pwd=admin123;");

                //Efetuar Teste
                if (result != null)
                    Assert.True(true, "GetById Sucesso");
                else
                    Assert.False(false, "GetById Falid");
            }
            catch (System.Exception ex)
            {
                Assert.False(false, "GetById" + ex.Message);
            }
        }

        [Fact]
        public void TesteInsert()
        {
            try
            {
                //Criação cenario
                IRepositoryPessoa repositoryPessoa = new RepositoryPessoa();
                Pessoa pessoa = new Pessoa();

                pessoa.Id = 0;
                pessoa.Nome_Documento = "Pessoa_Teste_Unitario nome documento";
                pessoa.Nome_Social = "Pessoa_Teste_Unitario nome social";
                pessoa.Sexo = 1;
                pessoa.Data_Nascimento = DateTime.Now;
                pessoa.Situacao_Familiar = "";
                pessoa.Cor_Pele = "";
                pessoa.Etinia = "";
                pessoa.Religiao = "";
                pessoa.Nome_Mae = "";
                pessoa.Nome_Pai = "";
                pessoa.Nome_Conjugue = "";
                pessoa.Cpf = "";
                pessoa.Rg = "";

                var result = repositoryPessoa.Insert(pessoa, "Server=localhost;Port=3306;Database=desenv_teste;Uid=root;Pwd=admin123;");

                if (result)
                {
                    Assert.True(true, "Insert sucesso");
                }
                else
                    Assert.False(false, "Insert falha");

            }
            catch (System.Exception ex)
            {
                Assert.False(false, "Insert" + ex.Message);
            }
        }

        [Fact]
        public void TesteDelete()
        {
            try
            {
                //Criação cenario
                IRepositoryPessoa repositoryPessoa = new RepositoryPessoa();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
