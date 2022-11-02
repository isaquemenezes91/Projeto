using ControleDeNota.Enum;
using System.Runtime.CompilerServices;

namespace ControleDeNota.Models
{
    public class NotaModel
    {
        

        public int Id { get; set; }
        

        public float NotaDaDisciplina { get; set; }

        public Disciplina Disciplina { get; set; }

        public NotaModel()
        {
            
            NotaDaDisciplina = 0;
            Disciplina = Disciplina.Portugues;
        }
    }
}
