using System;

namespace teste.Domain
{
    public class Lote
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public DateTime? dataInicio { get; set; }
        public DateTime? dataFim { get; set; }
        public int quantidade { get; set; }
        public int eventoId { get; set; } // Foreign key Evento.cs
        public Evento evento { get; set; } // Referencia do objeto com os dados, pega os dados relacionados ao id

    }
}