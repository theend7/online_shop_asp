using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class CenaConfiguration : IEntityTypeConfiguration<Cena>
    {
        public void Configure(EntityTypeBuilder<Cena> builder)
        {
            builder.Property(x => x.CenaP).IsRequired();
            
        }
    }
}
