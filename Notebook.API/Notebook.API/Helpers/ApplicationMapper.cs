using AutoMapper;
using Notebook.API.Data;
using Notebook.API.Models;

namespace Notebook.API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Notes, NoteModel>().ReverseMap();
        }
    }
}
