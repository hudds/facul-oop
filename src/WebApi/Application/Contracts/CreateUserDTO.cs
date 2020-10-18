using System.ComponentModel.DataAnnotations;

namespace FaculOop.WebApi.Application.Contracts
{
    /// <summary>
    /// Objeto de Transferência de Dados para criação de usuário.
    /// DataTransferObject
    /// </summary>
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "O usuáro é obrigatório.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; }
    }
}