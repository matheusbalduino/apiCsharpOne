using Microsoft.EntityFrameworkCore;
using teste.API.Model;

namespace teste.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Evento> Eventos { get; set; }
    }
}