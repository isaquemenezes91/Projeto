using ControleDeNota;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ControleDeNota.Models
{
    public class NotaModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int AlunoId { get; set; }
       

        [Required]
        public float NotaDaDisciplina { get; set; }

        [Required]
        public Disciplinas Disciplina { get; set; }


    }

}