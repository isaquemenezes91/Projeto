using ControleDeNota.Models;

namespace ControleDeNota.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {

        List<AlunoModel> MostrarTodosAlunos();
        AlunoModel BuscarPorId(int id);   
        void Adicionar( AlunoModel aluno);
        void Atualizar (AlunoModel aluno);
        void Remover(AlunoModel aluno);
    }
}
