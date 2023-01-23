using Demo.Contacts.API.Repository;
using Demo.RabbitMQ.Settings.Models.User;
using MassTransit;

namespace Demo.Contacts.API.Services
{
    public class UserUpdatedConsumer : IConsumer<UserUpdated>
    {
        private readonly IContactsRepository _contactsRepository;

        public UserUpdatedConsumer(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task Consume(ConsumeContext<UserUpdated> context)
        {
            var message = context.Message;

            if (message == null) return;

            var contact = await _contactsRepository.GetAsync(message.UserId);

            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            contact.ContactOwner = message.Name;
            _contactsRepository.Update(contact);
        }
    }
}
