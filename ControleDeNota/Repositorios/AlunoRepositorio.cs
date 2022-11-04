using ControleDeNota.Data;
using ControleDeNota.Models;
using ControleDeNota.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeNota.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio

    {
        private readonly SistemasDeNotasDBContext _dbContext;
       
        public AlunoRepositorio(SistemasDeNotasDBContext sistemasDeNotasDBContext)
        {
            _dbContext = sistemasDeNotasDBContext;
        }
        public async Task<AlunoModel> Adicionar(AlunoModel aluno)
        {
            await _dbContext.Alunos.AddAsync(aluno);
            await _dbContext.SaveChangesAsync();
            return aluno ;
        }

        public async Task<AlunoModel> Atualizar(AlunoModel aluno, int id)
        {
            AlunoModel alunoPorID = await BuscarPorId(id);
            if(alunoPorID == null)
            {
                throw new Exception($"Aluno com Id: {id} nao foi encontrado no Banco de dados");
            }
            alunoPorID.Nome = aluno.Nome;
            _dbContext.Update(alunoPorID);
            _dbContext.SaveChanges();

            return alunoPorID;
        }

        public async Task<AlunoModel> BuscarPorId(int id)

        {

            return await _dbContext.Alunos.Include(i=>i.Notas).FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<List<AlunoModel>> MostrarTodosAlunos()
        {
            return await _dbContext.Alunos.Include(i=>i.Notas).ToListAsync();
        }

        public async Task<bool> Remover(int id)
        {
            AlunoModel alunoPorID = await BuscarPorId(id);
            if (alunoPorID == null)
            {
                throw new Exception($"Aluno com Id: {id} nao foi encontrado no Banco de dados");
            }
            
            _dbContext.Remove(alunoPorID);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
