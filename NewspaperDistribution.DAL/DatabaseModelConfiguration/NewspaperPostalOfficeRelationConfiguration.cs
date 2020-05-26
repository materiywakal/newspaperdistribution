using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL.DatabaseModelConfiguration
{
    public class NewspaperPostalOfficeRelationConfiguration : IEntityTypeConfiguration<NewspaperPostalOfficeRelation>
    {
        public void Configure(EntityTypeBuilder<NewspaperPostalOfficeRelation> builder)
        {
            builder.ToTable("NewspaperPostalOffice");

            builder.HasKey(o => o.NewspaperPostalOfficeRelationId);
        }
    }
}
