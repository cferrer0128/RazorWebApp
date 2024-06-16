using BlazorAppWebApp.Model;
namespace BlazorAppWebApp.Services
{
    public interface INote
    {
        Task<IList<NoteModel>> GetAllNotes();
        Task<NoteModel> GetNoteById(int Id);
        Task<NoteModel> AddNote(NoteModel note);
    }
}
