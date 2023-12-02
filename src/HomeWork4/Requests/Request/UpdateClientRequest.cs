namespace Requests.Request
{
    public class UpdateClientRequest
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
