namespace Data.Responses
{
    public class CreateClientResponse
    {
        public Guid? ClientId { get; set; }

        public List<string>? Errors { get; set; }
    }
}
