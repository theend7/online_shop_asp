using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class SlikaConfiguration : IEntityTypeConfiguration<Slika>
    {
        public void Configure(EntityTypeBuilder<Slika> builder)
        {
            builder.Property(x => x.SlikaPutanja).HasMaxLength(150);
            builder.Property(x => x.SlikaPutanja).IsRequired();
            builder.HasIndex(x => x.SlikaPutanja).IsUnique();
            builder.Property(x => x.ProizvodId).IsRequired();
        }
    }
}
