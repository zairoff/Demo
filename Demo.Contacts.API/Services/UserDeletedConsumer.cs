using Demo.Contacts.API.Repository;
using Demo.RabbitMQ.Settings.Models.User;
using MassTransit;

namespace Demo.Contacts.API.Services
{
    public class UserDeletedConsumer : IConsumer<UserDeleted>
    {
        private readonly IContactsRepository _contactsRepository;

        public UserDeletedConsumer(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task Consume(ConsumeContext<UserDeleted> context)
        {
            var message = context.Message;

            if (message == null) return;

            var contact = await _contactsRepository.GetAsync(message.UserId);

            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            _contactsRepository.Delete(contact);
        }
    }
}
