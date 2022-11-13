using System.ComponentModel.DataAnnotations;

namespace ControleDeNota.Models
{
    public class LogError
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(500)]
        public string StackTrace { get; set; }

        [Required, MaxLength(200)]
        public string Mensagem { get; set; }

        [MaxLength(500)]
        public string? InnerException { get; set; }

        [Required]
        public DateTime DataHoraRegistro { get; set; }

        

    }
}
