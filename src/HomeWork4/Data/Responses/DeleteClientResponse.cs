namespace Data.Responses
{
    public class DeleteClientResponse
    {
        public bool IsDeleted { get; set; }

        public List<string>? Errors { get; set; }
    }
}
