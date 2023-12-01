namespace Data.Responses
{
    public class UpdateClientResponse
    {
        public bool IsUpdated { get; set; }

        public List<string>? Errors { get; set; }
    }
}
