using RallyDakar.Dominio.DbContexto;
using RallyDakar.Dominio.Entidades;
using RallyDakar.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyDakar.Dominio.Repositorios
{
    public class PilotoRepositorio : IPilotoRepositorio
    {

        private readonly RallyDbContexto _rallyDbContexto;


        public PilotoRepositorio(RallyDbContexto rallyDbContexto)
        {
            _rallyDbContexto = rallyDbContexto;
        }

        public void Adicionar(Piloto piloto)
        {
            _rallyDbContexto.Pilotos.Add(piloto);
            _rallyDbContexto.SaveChanges();
        }

        public IEnumerable<Piloto> ObterTodos()
        {
            return _rallyDbContexto.Pilotos.ToList();
        }

        public IEnumerable<Piloto> ObterTodosPilotosNome(string nome)
        {
            return _rallyDbContexto.Pilotos.Where(x => x.Nome.Contains(nome)).ToList();
        }

        public bool Existe(int id)
        {
            return (_rallyDbContexto.Pilotos.Any(x => x.Id == id));
        }

        public Piloto Obter(int pilotoId)
        {
            return (_rallyDbContexto.Pilotos.FirstOrDefault(x => x.Id == pilotoId));
        }

        public void Atualizar(Piloto piloto)
        {
            _rallyDbContexto.Attach(piloto);
            _rallyDbContexto.Entry(piloto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _rallyDbContexto.SaveChanges();
        }

        public void Deletar(Piloto piloto)
        {
            _rallyDbContexto.Pilotos.Remove(piloto);
            _rallyDbContexto.SaveChanges();
        }
    }
}
