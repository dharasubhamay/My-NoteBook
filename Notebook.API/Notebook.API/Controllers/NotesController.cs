using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Notebook.API.Models;
using Notebook.API.Repository;
using System.Threading.Tasks;

namespace Notebook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        // Get all notes
        [HttpGet("")]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _notesRepository.GetNoteByIdAsync();
            return Ok(notes);
        }

        // Get note by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById([FromRoute]int id)
        {
            var note = await _notesRepository.GetNoteByIdAsync(id);
            if(note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // Add new Note
        [HttpPost("")]
        public async Task<IActionResult> AddNewNote([FromBody]NoteModel noteModel)
        {
            var id = await _notesRepository.AddNoteAsync(noteModel);
            return CreatedAtAction(nameof(GetNoteById), new { id = id, controller="notes" }, id);
        }

        // Update a note by PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote([FromRoute] int id, [FromBody] NoteModel noteModel)
        {
            await _notesRepository.UpdateNoteAsync(id, noteModel);
            return Ok();
        }

        // Update a note by PATCH
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateNotePatch([FromRoute] int id, [FromBody] JsonPatchDocument noteModel)
        {
            await _notesRepository.UpdateNotePatchAsync(id, noteModel);
            return Ok();
        }

        // Delete a note
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            await _notesRepository.DeleteNoteAsync(id);
            return Ok();
        }
    }
}
