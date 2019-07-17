using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SaudePessoa.Test
{
    public class PessoaTests
    {
        private IRepositoryPessoa _IRepositoryPessoa;

        public PessoaTests(IRepositoryPessoa repositoryPessoa) => _IRepositoryPessoa = repositoryPessoa;

        [Fact]
        public void TestGetAll()
        {
            //Criação cenario
            var result = _IRepositoryPessoa.GetAll("Server=localhost;Port=3306;Database=db_desenvolvimento;Uid=root;Pwd=Pompom27;");

            if (result != null)
            {
                IEnumerable<Pessoa> ListPessoas = result;

                Assert.True(ListPessoas.ToList().Count > 0, "Teste Wod");
            }
        }
    }
}
