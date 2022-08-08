using Microsoft.AspNetCore.JsonPatch;
using Notebook.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notebook.API.Repository
{
    public interface INotesRepository
    {
        Task<List<NoteModel>> GetNoteByIdAsync();
        Task<NoteModel> GetNoteByIdAsync(int NoteId);
        Task<int> AddNoteAsync(NoteModel noteModel);
        Task UpdateNoteAsync(int NoteId, NoteModel noteModel);
        Task UpdateNotePatchAsync(int noteId, JsonPatchDocument noteModel);
        Task DeleteNoteAsync(int noteId);
    }
}
