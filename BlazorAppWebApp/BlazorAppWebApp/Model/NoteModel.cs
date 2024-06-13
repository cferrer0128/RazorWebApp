namespace BlazorAppWebApp.Model
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set;}
    }
}
