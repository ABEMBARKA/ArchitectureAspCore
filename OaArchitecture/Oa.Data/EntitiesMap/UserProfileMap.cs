namespace Oa.Data.EntitiesMap
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public  class UserProfileMap
    {
        public   UserProfileMap(EntityTypeBuilder<UserProfile> entity)
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Ipaddress)
                .HasColumnName("IPAddress")
                .HasMaxLength(20);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.IdNavigation)
                .WithOne(p => p.UserProfile)
                .HasForeignKey<UserProfile>(d => d.Id);
        }
    }
}