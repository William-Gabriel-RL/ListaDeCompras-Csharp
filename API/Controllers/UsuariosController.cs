using BusinessLayer.Model;
using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuarioService _service;
        public UsuariosController()
        {
            _service = new UsuarioService();
        }
        // POST: api/<UsuariosController>
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody]UsuarioCadastroDTO usuarioDTO)
        {
            return Created(String.Empty, _service.Cadastrar(usuarioDTO));
        }

        // POST: api/<UsuariosController>
        [HttpPost]
        public ActionResult<Usuario> Login([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            return Ok(_service.Login(usuarioLoginDTO));
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        [Authorize]
        public Usuario Get([FromQuery]int id)
        {
            return _service.Obter(id);
        }

        // PUT: api/<UsuariosController>
        [HttpPut]
        public Usuario Put([FromQuery] int id, [FromBody] UsuarioEditarDTO usuarioEditarDTO)
        {
            return _service.Editar(id, usuarioEditarDTO);
        }

        // DELETE: api/<UsuariosController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _service.Excluir(id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("404"))
                {
                    return NotFound("Usuário não Encontrado");
                }
            }
            return Ok("Usuário excluído com sucesso");

        }
    }
}
