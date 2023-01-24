using Demo.RabbitMQ.Settings.Models.Contact;
using Demo.Users.API.Repository;
using MassTransit;
using System.Diagnostics.CodeAnalysis;

namespace Demo.Users.API.Services
{
    [ExcludeFromCodeCoverage]
    public class ContactDeletedConsumer : IConsumer<ContactDeleted>
    {
        private readonly IUsersRepository _usersRepository;

        public ContactDeletedConsumer(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task Consume(ConsumeContext<ContactDeleted> context)
        {
            var message = context.Message;

            if (message == null) return;

            var user = await _usersRepository.GetAsync(message.UserId);

            if (user == null) throw new ArgumentNullException(nameof(user));

            user.Contact = string.Empty;

            _usersRepository.Update(user);
        }
    }
}
