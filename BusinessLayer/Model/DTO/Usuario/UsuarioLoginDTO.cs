using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Model.DTO.Usuario
{
    public class UsuarioLoginDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
