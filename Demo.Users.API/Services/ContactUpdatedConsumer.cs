using Demo.RabbitMQ.Settings.Models.Contact;
using Demo.Users.API.Repository;
using MassTransit;
using System.Diagnostics.CodeAnalysis;

namespace Demo.Users.API.Services
{
    [ExcludeFromCodeCoverage]
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
