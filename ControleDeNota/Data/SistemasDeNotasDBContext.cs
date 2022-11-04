using ControleDeNota.Data;
using ControleDeNota.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeNota.Data
{
    public class SistemasDeNotasDBContext : DbContext
    {
        public SistemasDeNotasDBContext(DbContextOptions<SistemasDeNotasDBContext> options)
            : base(options) 
        {
            
        }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<NotaModel> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
    