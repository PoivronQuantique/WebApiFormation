using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfiguration
{
    internal class WookieEntityTypeConfiguration : IEntityTypeConfiguration<Wookie>
    {
        public void Configure(EntityTypeBuilder<Wookie> builder)
        {
            builder.ToTable("Wookie");
            builder.HasKey(x => x.Id);
        }
    }
}
