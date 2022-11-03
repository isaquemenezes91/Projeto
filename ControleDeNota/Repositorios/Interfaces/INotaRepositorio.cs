using ControleDeNota.Models;

namespace ControleDeNota.Repositorios.Interfaces
{
    public interface INotaRepositorio
    {
        Task<NotaModel> AdicionarNota(NotaModel nota);
        Task<NotaModel> AtualizarNota(NotaModel nota, int id);
        Task<bool> RemoverNota(int id);

        Task<NotaModel> BuscarPorIDNota(int id);
    }
}
