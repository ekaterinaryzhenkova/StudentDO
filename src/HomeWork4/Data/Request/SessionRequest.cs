namespace Requests.Request
{
    public class SessionRequest
    {
        public Guid? Id { get; set; }
        public Guid MasseurId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime DateTime { get; set; }
        public string TypeOfMassage { get; set; }
    }
}
