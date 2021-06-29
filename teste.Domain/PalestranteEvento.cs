namespace teste.Domain
{
    public class PalestranteEvento
    {
        public int Id { get; set; }
        public int eventoId { get; set; }
        public int palestranteId { get; set; }

        public Palestrante palestrante { get; set; }
        public Evento evento { get; set; }
    }
}