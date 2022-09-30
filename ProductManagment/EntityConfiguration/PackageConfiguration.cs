using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductManagment.Entity
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>

    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasMany(b => b.PackageProducts).WithOne();

        }
    }
}
