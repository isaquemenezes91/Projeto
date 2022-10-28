using ControleDeNota.Data.Map;
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
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
    