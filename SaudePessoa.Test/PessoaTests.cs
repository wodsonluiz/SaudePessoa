using Microsoft.Extensions.Configuration;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using SaudePessoa.Data.Service;
using System.Collections.Generic;
using System.Linq;
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
    }
}
