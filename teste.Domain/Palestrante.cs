using System.Collections.Generic;

namespace teste.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string miniCurriculo { get; set; }
        public string imagemURL { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<RedeSocial> redeSociais { get; set; }
        
        public List<PalestranteEvento> palestrantesEventos { get; set; }
    }
}