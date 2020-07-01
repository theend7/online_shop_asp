using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class UlogaConfiguration : IEntityTypeConfiguration<Uloga>
    {
        public void Configure(EntityTypeBuilder<Uloga> builder)
        {
            builder.Property(x => x.NazivUloge).HasMaxLength(25).IsRequired();
            builder.HasMany(u => u.Klijenti).WithOne(k => k.Uloga).HasForeignKey(k => k.IdUloga).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
