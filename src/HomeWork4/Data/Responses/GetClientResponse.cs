namespace Data.Responses
{
    public class GetClientResponse
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public List<string>? Errors { get; set; }
    }
}
