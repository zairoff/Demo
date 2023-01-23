using Demo.RabbitMQ.Settings.Models.User;
using Demo.Users.API.Dtos;
using Demo.Users.API.Mapper;
using Demo.Users.API.Repository;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserMapper _userMapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UsersController(IUsersRepository usersRepository, IUserMapper userMapper, IPublishEndpoint publishEndpoint)
        {
            _usersRepository = usersRepository;
            _userMapper = userMapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _usersRepository.GetAsync(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _usersRepository.FindAsync(user => user.Name.Equals(name));

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] UserCreate userCreate)
        {
            var user = _userMapper.MapUser(userCreate);

            await _usersRepository.AddAsync(user);

            await _publishEndpoint.Publish(new UserCreated { UserId = user.Id, Name = user.Name });

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdate userUpdate)
        {
            var user = await _usersRepository.GetAsync(id);

            if (user == null)
            {
                return NotFound($"user for Id: {id} not found");
            }

            user = _userMapper.MapUser(userUpdate);

            _usersRepository.Update(user);

            await _publishEndpoint.Publish(new UserUpdated { UserId = user.Id, Name = user.Name });

            return Ok(user);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _usersRepository.GetAsync(id);

            if (user == null)
            {
                return NotFound($"user for Id: {id} not found");
            }

            _usersRepository.Delete(user);

            await _publishEndpoint.Publish(new UserDeleted { UserId = user.Id });

            return Ok(user);
        }
    }
}
