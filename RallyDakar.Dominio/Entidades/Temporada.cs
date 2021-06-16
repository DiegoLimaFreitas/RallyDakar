using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyDakar.Dominio.Entidades
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public virtual ICollection<Equipe> Equipes { get; set; }

        //Construtor da classe
        public Temporada()
        {
            Equipes = new List<Equipe>();
        }
        public void AdicionarEquipe(Equipe equipe)
        {
            //pré-condições

            if (equipe != null && equipe.ValidarCamposEquipe())

            {
                if (!Equipes.Any(e => e.Id == equipe.Id))
                {
                    Equipes.Add(equipe);
                }
            }
        }
        public Equipe ObterEquipeId(int id)
        {

            return Equipes.FirstOrDefault(x => x.Id == id);
        }
    }
}
