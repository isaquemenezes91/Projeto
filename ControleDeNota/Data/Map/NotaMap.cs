using ControleDeNota.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleDeNota.Data.Map
{
    
        public class NotaMap : IEntityTypeConfiguration<NotaModel>
        {
            public void Configure(EntityTypeBuilder<NotaModel> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.NotaDaDisciplina).IsRequired();
                builder.Property(x => x.Disciplina).IsRequired().HasMaxLength(50);
            }



        }
}
