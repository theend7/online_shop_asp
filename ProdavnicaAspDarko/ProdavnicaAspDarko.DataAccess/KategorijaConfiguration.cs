using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class KategorijaConfiguration : IEntityTypeConfiguration<Kategorija>
    {
        public void Configure(EntityTypeBuilder<Kategorija> builder)
        {
            builder.Property(x => x.NazivKategorije).HasMaxLength(60);
            builder.Property(x => x.NazivKategorije).IsRequired();
            builder.HasIndex(x => x.NazivKategorije).IsUnique();
            builder.HasMany(p => p.Proizvodi).WithOne(k => k.Kategorija).HasForeignKey(k => k.IdKategorija).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
