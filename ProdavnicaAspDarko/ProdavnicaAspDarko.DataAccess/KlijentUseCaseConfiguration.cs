using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.EFDataAccess
{
    public class KlijentUseCaseConfiguration : IEntityTypeConfiguration<KlijentUseCase>
    {
        public void Configure(EntityTypeBuilder<KlijentUseCase> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.KlijentId).IsRequired();
            builder.Property(x => x.UseCaseId).IsRequired();
        }
    }
}
