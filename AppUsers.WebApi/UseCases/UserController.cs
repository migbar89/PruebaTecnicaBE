using AppUsers.Dominio;
using AppUsers.Dominio.Exceptions;
using AppUsers.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnia.net7.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            try
            {
                var createdPerson = await _userService.CreateUserAsync(user);

                return CreatedAtAction(nameof(CreateUser), createdPerson);
            }
            catch (CoreValidationException ex)
            {
                return StatusCode(ex.GenericResponse().StatusCode, ex.GenericResponse());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var people = await _userService.GetUsersAsync();
                return Ok(people);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = ex.Message
                });
            }
        }

    }
}
