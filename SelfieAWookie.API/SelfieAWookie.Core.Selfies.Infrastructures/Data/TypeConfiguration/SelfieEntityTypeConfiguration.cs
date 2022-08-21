using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfiguration
{
    internal class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
    {
        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable("Selfie");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Wookie)
                    .WithMany(x=>x.Selfies);
        }
    }
}
