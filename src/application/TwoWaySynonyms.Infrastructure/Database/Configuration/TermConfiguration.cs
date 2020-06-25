using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwoWaySynonyms.DAO.Models;

namespace TwoWaySynonyms.Infrastructure.Database.Configuration
{
    public class TermConfiguration : IEntityTypeConfiguration<TermDAO>
    {
        public void Configure(EntityTypeBuilder<TermDAO> builder)
        {
            builder.ToTable("Terms");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnName("Term");
            builder.Property(x => x.RawSynonyms)
                .IsRequired()
                .HasColumnName("Synonyms");
        }
    }
}
