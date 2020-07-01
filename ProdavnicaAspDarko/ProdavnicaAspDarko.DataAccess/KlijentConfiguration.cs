using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class KlijentConfiguration : IEntityTypeConfiguration<Klijent>
    {
        public void Configure(EntityTypeBuilder<Klijent> builder)
        {
            builder.Property(x => x.Ime).HasMaxLength(30);
            builder.Property(x => x.Ime).IsRequired();
            builder.Property(x => x.Prezime).HasMaxLength(30);
            builder.Property(x => x.Prezime).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(55);
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Jmbg).IsRequired();
            builder.HasIndex(x => x.Jmbg).IsUnique();
            builder.Property(x => x.Lozinka).HasMaxLength(140);
            builder.Property(x => x.Lozinka).IsRequired();
            builder.Property(x => x.IdUloga).IsRequired();

            builder.HasMany(p => p.Porudzbine).WithOne(p => p.Klijent).HasForeignKey(p => p.KlijentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.KlijentUseCases).WithOne(p => p.Klijent).HasForeignKey(p => p.KlijentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
