using LoginManagemet.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginManagemet.DataContext.Maps
{
    public class MenuSubcategoryMap : IEntityTypeConfiguration<MenuSubcategory>
    {
        public void Configure(EntityTypeBuilder<MenuSubcategory> builder)
        {
            builder.ToTable("MenuSubcategories");
            builder.HasKey(e => e.Id).IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(70)").IsRequired(true).HasMaxLength(70);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(150)").IsRequired(true).HasMaxLength(150);
            builder.Property(x => x.MenuOptionId).HasColumnName(@"MenuOptionId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Reference).HasColumnName(@"Reference").HasColumnType("varchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.IsEnable).HasColumnName(@"IsEnable").IsRequired();           
        }
    }
}
