namespace Demo.Contacts.API.Models
{
    public class Contact
    {
        public Guid Id { get; set; }

        public Guid ContactOwnerId { get; set; }

        public string ContactOwner { get; set; }

        public ContactType? Type { get; set; }

        public string? ContactInfo { get; set; }
    }
}
