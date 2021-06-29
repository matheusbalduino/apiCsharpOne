using System;
using System.Collections.Generic;

namespace teste.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string local { get; set; }
        public DateTime dataEvento { get; set; }
        public string tema { get; set; }
        public int qtdPessoas { get; set; }
        public string imageUrl { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<Lote> lotes { get; set; }
        public List<RedeSocial> redeSociais { get; set; }
        public List<PalestranteEvento> palestrantesEventos { get; set; }
    }
}