using ControleDeNota.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleDeNota.Data.Map
{
    public class NotaMap : IEntityTypeConfiguration<NotaModel>
    {
        public void Configure(EntityTypeBuilder<NotaModel> builder)
        {
            builder.HasKey(x => x.NotaId);
            builder.Property(x => x.PrimeiraNota);
            builder.Property(x => x.SegundaNota);
            builder.Property(x => x.TerceiraNota);
        } 
    

    }
}
