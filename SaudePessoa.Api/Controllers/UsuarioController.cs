using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;

namespace SaudePessoa.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        protected readonly IRepositoryUsuario _repositoryUsuario;
        private IConfiguration _config;

        public UsuarioController(IRepositoryUsuario repositoryUsuario, IConfiguration config)
        {
            _repositoryUsuario = repositoryUsuario;
            _config = config;
        }

        [HttpPost]
        [Authorize("Bearer")]
        [Route("Logar")]
        public async Task<Usuario> Logar([FromBody] string strEmail, string password)
        {
            return await _repositoryUsuario.Logar(strEmail, password, _config.GetConnectionString("ExemplosDapper"));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            var result = await _repositoryUsuario.Insert(usuario, _config.GetConnectionString("ExemplosDapper"));

            if (result)
                return StatusCode(201);
            else
                return BadRequest();
        }

        [HttpDelete]
        [Authorize("Bearer")]
        [Route("/{email}")]
        public async Task<ActionResult> Delete(string email)
        {
            var result = await _repositoryUsuario.Desativar(email, _config.GetConnectionString("ExemplosDapper"));

            if (result)
                return StatusCode(204);
            else
                return BadRequest();
        }
    }
}