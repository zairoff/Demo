using System;

namespace Demo.RabbitMQ.Settings.Models.User
{
    public class UserUpdated
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
