using Microsoft.VisualStudio.TestTools.UnitTesting;
using RallyDakar.Dominio.Entidades;
using System.Linq;

namespace RallyDakar.Dominio.Testes.Temporadas
{

    [TestClass]
    public class AdicionarDuasEquipesTeste
    {
        Temporada temporada;
        Equipe equipe1;
        Equipe equipe2;
        Equipe equipeRetorno;

      [TestInitialize]
        public void Initialize()
        {
            temporada = new Temporada();
            temporada.Id = 1;
            temporada.Nome = "Temporada2021";

            equipe1 = new Equipe();
            equipe1.Id = 1;
            equipe1.Nome = "EquipeTeste1";

            equipe2 = new Equipe();
            equipe2.Id = 2;
            equipe2.Nome = "EquipeTeste2";
                        
            
            temporada.AdicionarEquipe(equipe1);
            temporada.AdicionarEquipe(equipe2);
            temporada.AdicionarEquipe(equipe2);

            equipeRetorno = temporada.ObterEquipeId(equipe2.Id);
        }
        [TestMethod]
        public void DuasEquipesAdionadas()
        {
            Assert.IsTrue(temporada.Equipes.Count() == 2);
        }
        [TestMethod]
        public void NomeEquipe2RetornoCorretamente()
        {
            Assert.IsTrue(equipe2.Nome == equipeRetorno.Nome);
        }
        [TestMethod]
        public void CodigoIdentificadorEquipe2RetornoCorretamente()
        {
            Assert.IsTrue(equipe2.CodigoIdentificador == equipeRetorno.CodigoIdentificador);
        }

    }
}
