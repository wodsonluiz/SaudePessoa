using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudePessoa.Api.Controllers
{
    [EnableCors("CorsPolicy")]
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
        [Authorize("Bearer")]
        public async Task<IEnumerable<Pessoa>> Get()
        {
            return await _IRepositoryPessoa.GetAll(_config.GetConnectionString("ExemplosDapper"));
        }

        [HttpGet]
        [Authorize("Bearer")]
        [Route("{Id}")]
        public async Task<Pessoa> Get(int Id)
        {
            return await _IRepositoryPessoa.GetById(Id, _config.GetConnectionString("ExemplosDapper"));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Pessoa pessoa)
        {
            var result = await _IRepositoryPessoa.Insert(pessoa, _config.GetConnectionString("ExemplosDapper"));

            if (result)
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpDelete]
        [Authorize("Bearer")]
        [Route("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var result = await _IRepositoryPessoa.Delete(Id, _config.GetConnectionString("ExemplosDapper"));

            if (result)
                return StatusCode(204);
            else
                return BadRequest();
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<ActionResult> Put([FromBody]Pessoa pessoa)
        {
            var result = await _IRepositoryPessoa.Update(pessoa, _config.GetConnectionString("ExemplosDapper"));

            if (result)
                return StatusCode(202);
            else
                return BadRequest();
        }
    }
}