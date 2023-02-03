using System;

namespace Demo.RabbitMQ.Settings.Models.Contact
{
    public class ContactUpdated
    {
        public Guid UserId { get; set; }

        public string Contact { get; set; }
    }
}
