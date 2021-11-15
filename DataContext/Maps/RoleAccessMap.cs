using LoginManagemet.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.Maps
{
    public class RoleAccessMap : IEntityTypeConfiguration<RoleAccess>
    {
        public void Configure(EntityTypeBuilder<RoleAccess> builder)
        {
            builder.ToTable("RoleAccess");
            builder.HasKey(e => e.Id).IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.LevelName).HasColumnName(@"LevelName").HasColumnType("varchar(70)").IsRequired().HasMaxLength(150);
            builder.Property(x => x.LevelOptionId).HasColumnName(@"LevelOptionId").HasColumnType("int").IsRequired();

        }
    }
}
