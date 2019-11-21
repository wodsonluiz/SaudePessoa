using HelloPackegerJekins.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;
using System.Collections.Generic;

namespace SaudePessoa.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        protected readonly IRepositoryPessoa _IRepositoryPessoa;
        private IConfiguration _config;
        private readonly IHelloWord helloWord;

        public PessoaController(IConfiguration config, IRepositoryPessoa repositoryPessoa, IHelloWord helloWord)
        {
            _config = config;
            _IRepositoryPessoa = repositoryPessoa;
            this.helloWord = helloWord;
        }

        /// <summary>
        /// GetAll pessoas.
        /// </summary>
        [HttpGet]
        [Authorize("Bearer")]
        [Route("GetAll")]
        public IEnumerable<Pessoa> GetAll()
        {
            return _IRepositoryPessoa.GetAll(_config.GetConnectionString("ExemplosDapper"));
        }

        /// <summary>
        /// GetById pessoa
        /// </summary>
        /// <param name="Id"></param>    
        [HttpGet]
        //[Authorize("Bearer")]
        [Route("GetById")]
        public Pessoa GetById(int Id)
        {
            return _IRepositoryPessoa.GetById(Id, _config.GetConnectionString("ExemplosDapper"));
        }

        /// <summary>
        /// Creates a Pessoa.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Id": 0,
        ///        "Nome_Documento": "",
        ///        "Nome_Social": "",
        ///        "Sexo": 1,
        ///        "Data_Nascimento": "",
        ///        "Situacao_Familiar": "",
        ///        "Cor_Pele": "",
        ///        "Etinia": "",
        ///        "Religiao": "",
        ///        "Nome_Mae": "",
        ///        "Nome_Pai": "",
        ///        "Nome_Conjugue": "",
        ///        "Cpf": "",
        ///        "Rg": ""
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Pessoa</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>   
        [HttpPost]
        [Authorize("Bearer")]
        [Route("Insert")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Insert([FromBody]Pessoa pessoa)
        {
            var result = _IRepositoryPessoa.Insert(pessoa, _config.GetConnectionString("ExemplosDapper"));

            if (result)
                return StatusCode(201);
            else
                return BadRequest();
        }

        /// <summary>
        /// Delete pessoa
        /// </summary>
        /// <param name="Id"></param>   
        [HttpDelete]
        [Authorize("Bearer")]
        [Route("Delete")]
        public bool Delete(int Id)
        {
            return _IRepositoryPessoa.Delete(Id, _config.GetConnectionString("ExemplosDapper"));
        }

        /// <summary>
        /// Update a Pessoa.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Id": 0,
        ///        "Nome_Documento": "",
        ///        "Nome_Social": "",
        ///        "Sexo": 1,
        ///        "Data_Nascimento": "",
        ///        "Situacao_Familiar": "",
        ///        "Cor_Pele": "",
        ///        "Etinia": "",
        ///        "Religiao": "",
        ///        "Nome_Mae": "",
        ///        "Nome_Pai": "",
        ///        "Nome_Conjugue": "",
        ///        "Cpf": "",
        ///        "Rg": ""
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly Update Pessoa</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpPut]
        [Authorize("Bearer")]
        [Route("Update")]
        public bool Update([FromBody]Pessoa pessoa)
        {
            return _IRepositoryPessoa.Update(pessoa, _config.GetConnectionString("ExemplosDapper"));
        }
    }
}