using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaudePessoa.Api.ProviderJWT;
using SaudePessoa.Data.Entities;
using SaudePessoa.Data.Interface;

namespace SaudePessoa.Api.Controllers
{
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private readonly IRepositoryUsuario _serviceUsuario;

        public TokenController(IRepositoryUsuario serviceUsuario, IConfiguration config)
        {
            _serviceUsuario = serviceUsuario;
            _config = config;
        }

        [Route("api/CreateToken")]
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateToken([FromBody]UsuarioToken usuarioToken )
        {
            if (string.IsNullOrEmpty(usuarioToken.strEmail) || string.IsNullOrEmpty(usuarioToken.strPassword))
                return Unauthorized();

            var usuario = _serviceUsuario.Logar(usuarioToken.strEmail, usuarioToken.strPassword, _config.GetConnectionString("ExemplosDapper"));

            if (usuario == null)
                return Unauthorized();

            var token = new TokenJWTBuilder()
                .AddSecurityKey(ProviderJWT.JWTSecurityKey.Create("Secret_Key-Cestech"))
                .AddSubject(usuario.email)
                .AddIssuer("Securiry.Bearer")
                .AddAudience("Securiry.Bearer")
                .AddClaim("UsuarioAPI", usuario.Id.ToString())
                .AddExpiry(5)
                .Builder();

            return Ok(token.value);
        }
    }
}