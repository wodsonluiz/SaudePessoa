using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using SaudePessoa.Data.Service;

namespace SaudePessoa.Api.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        protected readonly IRepositoryPessoa _IRepositoryPessoa;
        private IConfiguration _config;

        public PessoaController(IConfiguration config, IRepositoryPessoa repositoryPessoa)
        {
            _config = config;
            _IRepositoryPessoa = repositoryPessoa;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Pessoa> GetAll()
        {
            return _IRepositoryPessoa.GetAll(_config.GetConnectionString("ExemplosDapper"));
        }

        [HttpGet]
        [Route("GetById")]
        public Pessoa GetById(int Id)
        {
            return _IRepositoryPessoa.GetById(Id, _config.GetConnectionString("ExemplosDapper"));
        }

        [HttpPost]
        [Route("Insert")]
        public ActionResult Insert([FromBody]Pessoa pessoa)
        {
            var result = _IRepositoryPessoa.Insert(pessoa, _config.GetConnectionString("ExemplosDapper"));

            if (result)
                return StatusCode(200);
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(int Id)
        {
            return _IRepositoryPessoa.Delete(Id, _config.GetConnectionString("ExemplosDapper"));
        }
        [HttpPut]
        [Route("Update")]
        public bool Update([FromBody]Pessoa pessoa)
        {
            return _IRepositoryPessoa.Update(pessoa, _config.GetConnectionString("ExemplosDapper"));
        }
    }
}