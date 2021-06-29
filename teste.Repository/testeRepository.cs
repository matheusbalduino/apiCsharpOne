using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste.Domain;

namespace teste.Repository
{
    public class testeRepository : ItesteRepository
    {
        private testeContext _context;

        public testeRepository(testeContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> saveChangesAsync()
        {
            return ( await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Evento
                .Include(c => c.lotes)
                .Include(c => c.redeSociais);
            
            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.palestrantesEventos)
                    .ThenInclude(p => p.palestrante);
            }

            query = query.OrderByDescending(c => c.dataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventoAsyncById(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Evento
                .Include(c => c.lotes)
                .Include(c => c.redeSociais);
            
            if(includePalestrantes)
            {
                query = query
                    .Include(c => c.palestrantesEventos)
                    .ThenInclude(c => c.palestrante);
            }

            query = query.OrderByDescending(c => c.dataEvento).Where(c => c.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Evento
                .Include(c => c.lotes)
                .Include(c => c.redeSociais);
            
            if(includePalestrantes)
            {
                query = query
                    .Include(c => c.palestrantesEventos)
                    .ThenInclude(c => c.palestrante);
            }

            query = query.OrderByDescending(c => c.dataEvento)
                         .Where(c => c.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestranteAsync(int palestranteId, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.redeSociais);
            
            if(includeEvento)
            {
                query = query
                    .Include(p => p.palestrantesEventos)
                    .ThenInclude(p => p.evento);
            }

            query = query.OrderBy(p => p.nome).Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEvento)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                .Include(p => p.redeSociais);
            
            if(includeEvento)
            {
                query = query
                    .Include(p => p.palestrantesEventos)
                    .ThenInclude(p => p.evento);
            }

            query = query.OrderBy(p => p.nome).Where(p => p.nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}