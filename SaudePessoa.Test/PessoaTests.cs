using Microsoft.Extensions.Configuration;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SaudePessoa.Test
{
    public class PessoaTests
    {
        protected readonly IRepositoryPessoa _IRepositoryPessoa;
        private IConfiguration _config;

        public PessoaTests(IRepositoryPessoa repositoryPessoa, IConfiguration config)
        {
            this._IRepositoryPessoa = repositoryPessoa;
            this._config = config;
        }

        [Fact]
        public virtual void TestGetAll()
        {
            //Criação cenario
            var result = _IRepositoryPessoa.GetAll(_config.GetConnectionString("ExemplosDapper"));

            if (result != null)
            {
                IEnumerable<Pessoa> ListPessoas = result;

                Assert.True(ListPessoas.ToList().Count > 0, "Teste Wod");
            }
        }
    }
}
