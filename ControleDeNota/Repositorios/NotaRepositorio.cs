using ControleDeNota.Data;
using ControleDeNota.Models;
using ControleDeNota.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeNota.Repositorios
{

    public class NotaRepositorio : INotaRepositorio
    {

        private SistemasDeNotasDBContext _ctx;

        public NotaRepositorio(SistemasDeNotasDBContext ctx)
        {
            _ctx = ctx;
        }

        public void AdicionarNota(NotaModel nota)
        {
            _ctx.Notas.Add(nota);
            _ctx.SaveChanges();
        }

        public void AtualizarNota(NotaModel nota)
        {
            _ctx.Update(nota);
            _ctx.SaveChanges();
        }

        public NotaModel BuscarPorIDNota(int id)
        {
            return _ctx.Notas
                .FirstOrDefault(i => i.Id.Equals(id));
        }

        public void RemoverNota(NotaModel nota)
        {
            
            _ctx.Notas.Remove(nota);
        }
        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}

