namespace teste.Domain
{
    public class PalestranteEvento
    {
        public int paletranteId { get; set; }
        public int eventoId { get; set; }

        public Palestrante palestrante { get; set; }
        public Evento evento { get; set; }
    }
}