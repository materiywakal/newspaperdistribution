using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL.DatabaseModelConfiguration
{
    public class NewspaperPrintingHouseRelationConfiguration : IEntityTypeConfiguration<NewspaperPrintingHouseRelation>
    {
        public void Configure(EntityTypeBuilder<NewspaperPrintingHouseRelation> builder)
        {
            builder.ToTable("NewspapersPrintingHouse");

            builder.HasKey(o => o.NewspaperPrintingHouseRelationId);
        }
    }
}
