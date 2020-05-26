using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL.DatabaseModelConfiguration
{
    public class PrintingHouseModelConfiguration : IEntityTypeConfiguration<PrintingHouseModel>
    {
        public void Configure(EntityTypeBuilder<PrintingHouseModel> builder)
        {
            builder.ToTable("PrintingHouses");

            builder.HasKey(e => e.PrintingHouseId);
        }
    }
}
