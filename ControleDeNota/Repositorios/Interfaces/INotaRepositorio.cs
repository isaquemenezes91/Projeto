using ControleDeNota.Models;

namespace ControleDeNota.Repositorios.Interfaces
{
    public interface INotaRepositorio
    {
        void AdicionarNota(NotaModel nota);
        void AtualizarNota(NotaModel nota);
        void RemoverNota(NotaModel nota);
        NotaModel BuscarPorIDNota(int id);
    }
}
