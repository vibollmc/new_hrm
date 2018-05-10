using Hris.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hris.Database
{
    /// <summary>
    /// Main Db context
    /// </summary>
    public class HrisContext : DbContext
    {
        /// <summary>
        /// All action of functions in systems
        /// </summary>
        public DbSet<Action> Actions { get; set; }

        /// <summary>
        /// Language of Actions
        /// </summary>
        public DbSet<ActionLanguage> ActionLanguages { get; set; }

        /// <summary>
        /// Setting form's languages
        /// </summary>
        public DbSet<FormLanguage> FormLanguages { get; set; }

        /// <summary>
        /// All functions of system, to be build menu
        /// </summary>
        public DbSet<Function> Functions { get; set; }

        /// <summary>
        /// Setting Function's Actions
        /// </summary>
        public DbSet<FunctionAction> FunctionActions { get; set; }

        /// <summary>
        /// Setting Function's Languages
        /// </summary>
        public DbSet<FunctionLanguage> FunctionLanguages { get; set; }

        /// <summary>
        /// Availiable Languages on system
        /// </summary>
        public DbSet<Language> Languages { get; set; }

        /// <summary>
        /// All Role permission on system
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Setting Role on functions
        /// </summary>
        public DbSet<RoleFunction> RoleFunctions { get; set; }

        /// <summary>
        /// Setting Role on function's Actions
        /// </summary>
        public DbSet<RoleFunctionAction> RoleFunctionActions { get; set; }

        /// <summary>
        /// Users login
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// User's roles
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        public HrisContext(DbContextOptions<HrisContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionLanguage>()
                .HasKey(x => new { x.ActionId, x.LanguageId });

            modelBuilder.Entity<FunctionAction>()
                .HasKey(x => new { x.ActionId, x.FunctionId });

            modelBuilder.Entity<FunctionLanguage>()
                .HasKey(x => new { x.FunctionId, x.LanguageId});

            modelBuilder.Entity<RoleFunction>()
                .HasKey(x => new {x.FunctionId, x.RoleId});

            modelBuilder.Entity<RoleFunctionAction>()
                .HasKey(x => new {x.RoleId, x.ActionId, x.FunctionId});

            modelBuilder.Entity<User>()
                .HasIndex(c => c.Username)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasKey(x => new {x.RoleId, x.UserId});
        }
    }
}
