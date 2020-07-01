using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class PorudzbinaConfiguration : IEntityTypeConfiguration<Porudzbina>
    {
        public void Configure(EntityTypeBuilder<Porudzbina> builder)
        {
            builder.Property(p => p.PorudzbinaStatus).HasDefaultValue(PorudzbinaStatus.Primljena);
            builder.HasMany(p => p.DetaljiPorudzbina).WithOne(dp => dp.Porudzbina).HasForeignKey(dp => dp.PorudzbinaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
