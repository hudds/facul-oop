using System;
using System.Net;
using FaculOop.WebApi.Application.Contracts;
using FaculOop.WebApi.Application.Services;
using FaculOop.WebApi.Domain.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FaculOop.WebApi.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserAppService _userAppService;

        public UsersController(UserAppService userAppService)
        {
            _userAppService = userAppService ?? throw new ArgumentNullException(nameof(userAppService));
        }

        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <param name="createUser">Contrato de criação.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDTO createUser)
        {
            var userId = _userAppService.Create(createUser);
            return new ObjectResult(userId)
            {
                StatusCode = (int) HttpStatusCode.Created
            };
            
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() {
            var list = _userAppService.GetAll();
            return Ok(list);
        }

        /// <summary>
        /// Obtém um usuário pelo identificador.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            try
            {
                var user = _userAppService.GetById(userId);
                return Ok(user);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Atualiza um usuário pelo identificador.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <param name="updateUser">Contrato de atualização.</param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public IActionResult UpdateById(int userId, [FromBody] UpdateUserDTO updateUser)
        {
            try
            {
                _userAppService.Update(userId, updateUser);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Remove um usuário através do identificador.
        /// </summary>
        /// <param name="userId">Identificador do usuário</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public IActionResult DeleteById(int userId)
        {
            try
            {
                _userAppService.RemoveById(userId);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}