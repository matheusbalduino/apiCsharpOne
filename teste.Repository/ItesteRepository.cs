using System.Threading.Tasks;
using teste.Domain;

namespace teste.Repository
{
    public interface ItesteRepository
    {
         void Add<T>(T entity) where T : class;

         void Update<T> (T entity) where T : class;

         void Delete<T> (T entity) where T : class;

         Task<bool> saveChangesAsync();

         // EVENTOS
         Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
         Task<Evento> GetAllEventoAsyncById(int eventoId, bool includePalestrantes);

         // PALESTRANTE
         Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEvento);
         Task<Palestrante> GetAllPalestranteAsync(int palestranteId, bool includeEvento);


    }
}