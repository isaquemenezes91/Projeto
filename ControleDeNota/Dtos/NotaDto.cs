namespace ControleDeNota.Dtos
{
    public class NotaDto
    {
        public int AlunoId { get; set; }
        public float Nota { get; set; }

        public Disciplinas Disciplina { get; set; }   

        
    }
}
