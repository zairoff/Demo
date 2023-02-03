using Demo.Gateway.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Gateway.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersInfrastructure _usersInfrastructure;

        public UsersController(IUsersInfrastructure usersInfrastructure)
        {
            _usersInfrastructure = usersInfrastructure;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersInfrastructure.GetUsersAsync();

            return Ok(result);
        }
    }
}
