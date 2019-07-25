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
        public Usuario Logar([FromBody] string strEmail, string password)
        {
            return _repositoryUsuario.Logar(strEmail, password, _config.GetConnectionString("ExemplosDapper"));
        }

        [HttpPost]
        [Authorize("Bearer")]
        [Route("Inserir")]
        public bool Inserir([FromBody] Usuario usuario)
        {
            return _repositoryUsuario.Insert(usuario, _config.GetConnectionString("ExemplosDapper"));
        }

        [HttpPost]
        [Authorize("Bearer")]
        [Route("Desativar")]
        public bool Desativar([FromBody] string email)
        {
            return _repositoryUsuario.Desativar(email, _config.GetConnectionString("ExemplosDapper"));
        }
    }
}