using Demo.RabbitMQ.Settings.Models.Contact;
using Demo.Users.API.Repository;
using MassTransit;

namespace Demo.Users.API.Services
{
    public class ContactUpdatedConsumer : IConsumer<ContactUpdated>
    {
        private IUsersRepository _usersRepository;

        public ContactUpdatedConsumer(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task Consume(ConsumeContext<ContactUpdated> context)
        {
            var message = context.Message;

            if (message == null) return;

            var user = await _usersRepository.GetAsync(message.UserId);

            if (user == null) { throw new ArgumentNullException(nameof(user)); }

            user.Contact = message.Contact;

            _usersRepository.Update(user);
        }
    }
}
