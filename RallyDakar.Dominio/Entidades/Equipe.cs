using System;
using System.Collections.Generic;
using System.Text;

namespace RallyDakar.Dominio.Entidades
{
    public class Equipe
    {

        public int Id { get; set; }
        public string CodigoIdentificador { get; set; }
        public string Nome { get; set; }

        public int TemporadaId { get; set; }

        //Quando o sistema estiver em execução o entity framework pode carregar por demanda, mudando a instancia em tempo de execução
        public virtual Temporada Temporada { get; set; }

        public ICollection<Piloto> Pilotos { get; set; }
    }
}
