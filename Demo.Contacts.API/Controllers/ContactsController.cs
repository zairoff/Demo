using Demo.Contacts.API.Dtos;
using Demo.Contacts.API.Mappers;
using Demo.Contacts.API.Repository;
using Demo.RabbitMQ.Settings.Models.Contact;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Contacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IContactsMapper _contactsMapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ContactsController(IContactsRepository usersRepository, IContactsMapper contactMapper, IPublishEndpoint publishEndpoint)
        {
            _contactsRepository = usersRepository;
            _contactsMapper = contactMapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contactsRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _contactsRepository.GetAsync(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByUserName")]
        public async Task<IActionResult> GetByUserName(string name)
        {
            var result = await _contactsRepository.FindAsync(user => user.ContactOwner.Equals(name));

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] ContactUpdate contactUpdate)
        {
            var contact = await _contactsRepository.GetAsync(id);

            if (contact == null)
            {
                return NotFound($"Contact for Id: {id} not found");
            }

            contact = _contactsMapper.MapContact(contactUpdate);

            _contactsRepository.Update(contact);

            await _publishEndpoint.Publish(new ContactUpdated { UserId = contact.ContactOwnerId, Contact = contact.ContactInfo });

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var contact = await _contactsRepository.GetAsync(id);

            if (contact == null)
            {
                return NotFound($"Contact for Id: {id} not found");
            }

            _contactsRepository.Delete(contact);

            await _publishEndpoint.Publish(new ContactDeleted { UserId = contact.ContactOwnerId });

            return Ok(contact);
        }
    }
}
