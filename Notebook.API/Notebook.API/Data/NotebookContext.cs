using Microsoft.EntityFrameworkCore;

namespace Notebook.API.Data
{
    public class NotebookContext : DbContext
    {
        public NotebookContext(DbContextOptions<NotebookContext> options) : base(options)
        {

        }

        public DbSet<Notes> Notes { get; set; }
    }
}
