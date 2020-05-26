using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL.DatabaseModelConfiguration
{
    public class NewspaperModelConfiguration : IEntityTypeConfiguration<NewspaperModel>
    {
        public void Configure(EntityTypeBuilder<NewspaperModel> builder)
        {
            builder.ToTable("Newspapers");

            builder.HasKey(e => e.NewspaperId);
        }
    }
}
