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
        [Authorize("Bearer")]
        [Route("Inserir")]
        public async Task<bool> Inserir([FromBody] Usuario usuario)
        {
            return await _repositoryUsuario.Insert(usuario, _config.GetConnectionString("ExemplosDapper"));
        }

        [HttpPost]
        [Authorize("Bearer")]
        [Route("Desativar")]
        public async Task<bool> Desativar([FromBody] string email)
        {
            return await _repositoryUsuario.Desativar(email, _config.GetConnectionString("ExemplosDapper"));
        }
    }
}