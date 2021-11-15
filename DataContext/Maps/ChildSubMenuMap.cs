using LoginManagemet.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.Maps
{
    public class ChildSubMenuMap : IEntityTypeConfiguration<ChildSubMenu>
    {
        public void Configure(EntityTypeBuilder<ChildSubMenu> builder)
        {
            builder.ToTable("ChildSubMenus");
            builder.HasKey(e => e.Id).IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Subcategory_id).HasColumnName(@"Subcategory_id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(150)").IsRequired(true).HasMaxLength(150);
            builder.Property(x => x.Reference).HasColumnName(@"Reference").HasColumnType("varchar(100)").IsRequired(false).HasMaxLength(100);
        }
    }
}
