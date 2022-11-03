using ControleDeNota.Data;
using ControleDeNota.Models;
using ControleDeNota.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeNota.Repositorios
{
    
    public class NotaRepositorio : INotaRepositorio
    {
        private readonly SistemasDeNotasDBContext _dbContext;
        public NotaRepositorio(SistemasDeNotasDBContext sistemasDeNotasDBContext)
        {
            _dbContext = sistemasDeNotasDBContext;
        }
        public async Task<NotaModel> BuscarPorIDNota(int id)

        {

            return await _dbContext.Notas.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<NotaModel> AdicionarNota(NotaModel nota)
        {
            
            await _dbContext.Notas.AddAsync(nota);
            await _dbContext.SaveChangesAsync();
            return nota;
        }
        
        public async Task<NotaModel> AtualizarNota(NotaModel nota, int id)
        {
            NotaModel NotaPorID = await BuscarPorIDNota(id);
            if (NotaPorID == null)
            {
                throw new Exception($"Nota com Id: {id} nao foi encontrado no Banco de dados");
            }
            NotaPorID.NotaDaDisciplina = nota.NotaDaDisciplina;
            _dbContext.Update(NotaPorID);
            _dbContext.SaveChanges();

            return NotaPorID;
        }

        public Task<bool> RemoverNota(int id)
        {
            throw new NotImplementedException();
        }
    }
}

