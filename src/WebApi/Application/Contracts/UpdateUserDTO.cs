using System.ComponentModel.DataAnnotations;

namespace FaculOop.WebApi.Application.Contracts
{
    /// <summary>
    /// Objeto de Transferência de Dados para atualização de usuário.
    /// DataTransferObject
    /// </summary>
    public class UpdateUserDTO
    {

        [Required(ErrorMessage = "O usuáro é obrigatório.")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password;
    }
}