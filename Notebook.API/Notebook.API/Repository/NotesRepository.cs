using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Notebook.API.Data;
using Notebook.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.API.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotebookContext _context;
        private readonly IMapper _mapper;

        public NotesRepository(NotebookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all Notes 
        public async Task<List<NoteModel>> GetNoteByIdAsync()
        {
            //var records = await _context.Notes.Select(x => new NoteModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).ToListAsync();

            //return records;

            // Get all Notes by Auto Mapper
            var records = await _context.Notes.ToListAsync();
            return _mapper.Map<List<NoteModel>>(records);
        }

        // Get single Note by Id
        public async Task<NoteModel> GetNoteByIdAsync(int NoteId)
        {
            //var record = await _context.Notes.Where(x=>x.Id == NoteId).Select(x => new NoteModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return record;

            // Get Note by Id using AutoMapper
            var note = await _context.Notes.FindAsync(NoteId);
            return _mapper.Map<NoteModel>(note);
        }

        // Add new Note
        public async Task<int> AddNoteAsync(NoteModel noteModel)
        {
            var note = new Notes() 
            {
                Title = noteModel.Title,
                Description = noteModel.Description
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return note.Id;
        }

        // Update a Note
        public async Task UpdateNoteAsync(int NoteId, NoteModel noteModel)
        {
            // This following code hits the database 2 times, once during finding note & once
            // during changes in perticular note

            //var note = await _context.Notes.FindAsync(NoteId);
            //if(note != null)
            //{
            //    note.Title = noteModel.Title;
            //    note.Description = noteModel.Description;

            //    await _context.SaveChangesAsync();
            //}

            // This following code hits the database once, 
            // this method simply create an object by updated once and replace with the previous once
            var note = new Notes()
            {
                Id = NoteId,
                Title = noteModel.Title,
                Description = noteModel.Description
            };

            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        // Update a note by Patch
        public async Task UpdateNotePatchAsync(int noteId, JsonPatchDocument noteModel)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if(note != null)
            {
                noteModel.ApplyTo(note);
                await _context.SaveChangesAsync();
            }
        }

        //Delete a note
        public async Task DeleteNoteAsync(int noteId)
        {
            //if noteId is not a primary key
            //var note = _context.Notes.Where(x => x.Id == noteId).FirstOrDefaultAsync();

            //if noteId is a primary key
            var note = new Notes()
            {
                Id = noteId
            };

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }
    }  
}
