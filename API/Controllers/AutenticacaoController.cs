using API.Services.Token;
using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        public UsuarioService _usuarioService { get; set; }
        public AutenticacaoController ()
        {
            _usuarioService = new UsuarioService();
        }

        // POST api/<AutenticacaoController>
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            var usuario = _usuarioService.Login(usuarioLoginDTO);
            if (usuario != null)
            {
                return Ok(TokenService.GerarToken(usuario));
            }
            return Unauthorized("Usuário não existe");
        }
    }
}
