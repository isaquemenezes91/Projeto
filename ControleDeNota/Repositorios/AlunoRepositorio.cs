using ControleDeNota.Data;
using ControleDeNota.Models;
using ControleDeNota.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeNota.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio

    {

        private SistemasDeNotasDBContext _ctx;
        public AlunoRepositorio(SistemasDeNotasDBContext ctx)
        {
            _ctx = ctx;
        }

        public List<AlunoModel> MostrarTodosAlunos()
        {
            return _ctx.Alunos.ToList();
        }
        public void Adicionar(AlunoModel aluno)
        {
            _ctx.Alunos.Add(aluno);
            _ctx.SaveChanges();
        }

        public void Atualizar(AlunoModel aluno)
        {
            _ctx.Update(aluno);
            _ctx.SaveChanges();
        }

        public AlunoModel BuscarPorId(int id)
        {
            return _ctx.Alunos
                .Include(i => i.Notas)
                .FirstOrDefault(j => j.Id.Equals(id));
        }



        public void Remover(AlunoModel aluno)
        {
            _ctx.Alunos.Remove(aluno);
        }


        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
