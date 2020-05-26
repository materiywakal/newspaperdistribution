using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewspaperDistribution.Domain.Models;

namespace NewspaperDistribution.DAL.DatabaseModelConfiguration
{
    public class PostalOfficeModelConfiguration : IEntityTypeConfiguration<PostalOfficeModel>
    {
        public void Configure(EntityTypeBuilder<PostalOfficeModel> builder)
        {
            builder.ToTable("PostalOffices");

            builder.HasKey(e => e.PostalOfficeId);
        }
    }
}
