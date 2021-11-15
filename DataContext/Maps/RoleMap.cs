using LoginManagemet.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginManagemet.DataContext.Maps
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(e => e.Id).IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(70)").IsRequired(true).HasMaxLength(70);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(150)").IsRequired(true).HasMaxLength(150);
            builder.Property(x => x.IsEnable).HasColumnName(@"IsEnable").IsRequired();
        }
    }
}
