using MarketplaceApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketplaceApi.Data.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("now()");
        }
    }
}
