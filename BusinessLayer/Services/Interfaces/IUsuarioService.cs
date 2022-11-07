using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Model;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Usuario Cadastrar(UsuarioCadastroDTO usuario);
        public Usuario Editar(int id, UsuarioEditarDTO usuario);
        public Usuario Obter(int id);
        public Usuario Login(UsuarioLoginDTO usuario);
    }
}