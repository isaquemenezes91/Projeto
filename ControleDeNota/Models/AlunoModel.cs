namespace ControleDeNota.Models
{
    public class AlunoModel
    {
        public AlunoModel()
        {
            
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        
        public List<NotaModel>? Notas { get; set; } 

        

    }

}
