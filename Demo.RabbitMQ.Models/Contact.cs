using System;

namespace Demo.RabbitMQ.Models
{
    public class Contact
    {
        public Guid UserId { get; set; }

        public string ContactInfo { get; set; }
    }
}
