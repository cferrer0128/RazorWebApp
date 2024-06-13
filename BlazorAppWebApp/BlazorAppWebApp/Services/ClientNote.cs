using BlazorAppWebApp.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace BlazorAppWebApp.Services
{
    public class ClientNote : INote
    {
        private readonly HttpClient _httpClient;

        public ClientNote(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NoteModel> AddNote(NoteModel note)
        {
            var stringPayLoad = JsonConvert.SerializeObject(note);
            var httpContent = new StringContent(stringPayLoad, System.Text.Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("/api/Notes", httpContent);
            if (result.IsSuccessStatusCode)            
            {               
                return JsonConvert.DeserializeObject<NoteModel>(await result.Content.ReadAsStringAsync())!;
            }else
            {
                return new NoteModel();
            }
            
        }

        public async Task<IList<NoteModel>> GetAllNotes()
        {
            var result = await _httpClient.GetAsync("/api/notes");
            return JsonConvert.DeserializeObject<IList<NoteModel>>(await result.Content.ReadAsStringAsync())!;
                
        }

        public Task<NoteModel> GetNoteById(int Id)
        {

            throw new NotImplementedException();
        }

       
    }
}
