using System;

namespace Demo.RabbitMQ.Settings.Models.User
{
    public class UserCreated
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
