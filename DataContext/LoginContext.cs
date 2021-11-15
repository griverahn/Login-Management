using LoginManagemet.DataContext.Entities;
using LoginManagemet.DataContext.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext
{
    public class LoginContext : DbContext
    {
        public LoginContext()
        {
        }

        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<MenuOption> MenuOptions { get; set; }
        public DbSet<MenuSubcategory> MenuSubcategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }
        public DbSet<ChildSubMenu> ChildSubMenu { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
