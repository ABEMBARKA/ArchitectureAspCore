namespace Oa.Data.EntitiesMap
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public  class UserMap
    {
        public   UserMap(EntityTypeBuilder<User> entity)
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Ipaddress)
                .HasColumnName("IPAddress")
                .HasMaxLength(20);

            entity.Property(e => e.Password).IsRequired();

            entity.Property(e => e.UserName).HasMaxLength(50);
        }
    }
}