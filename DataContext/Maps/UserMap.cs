using LoginManagemet.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginManagemet.DataContext.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id).IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AccountName).HasColumnName(@"AccountName").HasColumnType("varchar(40)").IsRequired(true).HasMaxLength(40);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(80)").IsRequired(true).HasMaxLength(80);
            builder.Property(x => x.Surname).HasColumnName(@"Surname").HasColumnType("varchar(80)").IsRequired(true).HasMaxLength(80);
            builder.Property(x => x.Password).HasColumnName(@"Password").HasColumnType("varchar(250)").IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar(250)").IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.RoleId).HasColumnName(@"RoleId").HasColumnType("int").IsRequired();
            builder.Property(x => x.IsEnable).HasColumnName(@"IsEnable").IsRequired();
        }
    }
}
