using Microsoft.EntityFrameworkCore;
using teste.Domain;

namespace teste.Repository
{
    public class testeContext: DbContext
    {
        public testeContext(DbContextOptions<testeContext> options) : base(options) {}
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.eventoId, PE.palestranteId});
        }
    }
}