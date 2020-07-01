using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class ProizvodConfiguration : IEntityTypeConfiguration<Proizvod>
    {
        public void Configure(EntityTypeBuilder<Proizvod> builder)
        {
            builder.Property(x => x.NazivProizvoda).HasMaxLength(60);
            builder.HasIndex(x => x.NazivProizvoda).IsUnique();
            builder.Property(x => x.NazivProizvoda).IsRequired();
            builder.Property(x => x.OpisProizvoda).HasMaxLength(200);
            builder.Property(x => x.OpisProizvoda).IsRequired();
            builder.Property(x => x.KolicinaProizvoda).IsRequired();
            builder.Property(x => x.SlikaProizvoda).HasMaxLength(150);
            builder.Property(x => x.SlikaProizvoda).IsRequired();
            builder.Property(x => x.IdKategorija).IsRequired();
            builder.HasMany(c => c.Cene).WithOne(p=> p.Proizvod).HasForeignKey(p => p.ProizvodId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c => c.Slike).WithOne(p => p.Proizvod).HasForeignKey(p => p.ProizvodId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.DetaljiPorudzbina).WithOne(p => p.Proizvod).HasForeignKey(p => p.ProizvodId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
