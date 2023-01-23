using Demo.Contacts.API.Models;
using Demo.Contacts.API.Repository;
using Demo.RabbitMQ.Settings.Models.User;
using MassTransit;

namespace Demo.Contacts.API.Services
{
    public class UserCreatedConsumer : IConsumer<UserCreated>
    {
        private readonly IContactsRepository _contactsRepository;

        public UserCreatedConsumer(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            var message = context.Message;

            if (message == null) return;

            var contact = await _contactsRepository.GetAsync(message.UserId);

            if (contact == null)
            {
                contact = new Contact { ContactOwnerId = message.UserId, ContactOwner = message.Name };
                await _contactsRepository.AddAsync(contact);
            }
        }
    }
}
