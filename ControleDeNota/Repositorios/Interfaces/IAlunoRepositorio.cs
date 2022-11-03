using ControleDeNota.Models;

namespace ControleDeNota.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {

        Task<List<AlunoModel>> MostrarTodosAlunos();
        Task<AlunoModel> BuscarPorId(int id);   
        Task<AlunoModel> Adicionar( AlunoModel aluno);
        Task<AlunoModel> Atualizar (AlunoModel aluno, int id);
        Task<bool> Remover(int id);
    }
}
