using Notebook.API.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Notebook.API.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        internal void ApplyTo(Notes note)
        {
            throw new NotImplementedException();
        }
    }
}
