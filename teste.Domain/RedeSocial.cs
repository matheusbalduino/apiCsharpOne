namespace teste.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string URL { get; set; }
        public int? eventoId { get; set; }
        public int? palestranteId { get; set; }
        public Evento evento { get; set; }
        public Palestrante palestrante { get; set; }
        
    }
}