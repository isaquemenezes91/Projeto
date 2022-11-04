using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeNota.Models
{
    public class AlunoModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Nome { get; set; }

        [ForeignKey("AlunoId")]
        public List<NotaModel>? Notas { get; set; } 

        

    }

}
