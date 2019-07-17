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
                IRepositoryPessoa repositoryPessoa = new RepositoryPessoa();

                //Criação cenario
                var result = repositoryPessoa.GetAll("Server=localhost;Port=3306;Database=desenv_teste;Uid=root;Pwd=admin123;");

                if (result != null)
                {
                    IEnumerable<Pessoa> ListPessoas = result;

                    Assert.True(ListPessoas.ToList().Count > 0, "Teste Wod");
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
            
        }
    }
}
