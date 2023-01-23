using System;

namespace Demo.RabbitMQ.Settings.Models.Contact
{
    public class ContactCreated
    {
        public Guid UserId { get; set; }

        public string Contact { get; set; }
    }
}
