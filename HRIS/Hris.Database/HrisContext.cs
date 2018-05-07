using System;
using Hris.Database.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Hris.Database
{
    /// <summary>
    /// Main Db context
    /// </summary>
    public class HrisContext : DbContext
    {
        /// <summary>
        /// Store users login
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Store Audit logs
        /// </summary>
        public DbSet<AuditLog> AuditLogs { get; set; }

        /// <summary>
        /// Store setting form's languages
        /// </summary>
        public DbSet<FormLanguage> FormLanguages { get; set; }

        /// <summary>
        /// Store all functions of system, to be build menu
        /// </summary>
        public DbSet<Function> Functions { get; set; }

        /// <summary>
        /// Store availiable languages on system
        /// </summary>
        public DbSet<Language> Languages { get; set; }

        /// <summary>
        /// Store all Role permission on system
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// Store setting Role on functuions
        /// </summary>
        public DbSet<RoleFunction> RoleFunctions { get; set; }

        /// <summary>
        /// Store user's roles
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        public HrisContext(DbContextOptions<HrisContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(c => c.Username)
                .IsUnique();

        }
    }
}
