using Hris.Database.Entities;
using Hris.Database.Entities.Common;
using Hris.Database.Entities.List;
using Microsoft.EntityFrameworkCore;

namespace Hris.Database
{
    /// <inheritdoc />
    /// <summary>
    /// Main Db context
    /// </summary>
    public class HrisContext : DbContext
    {

        #region common
        /// <summary>
        /// All action of functions in systems
        /// </summary>
        public DbSet<MDAction> Actions { get; set; }

        /// <summary>
        /// Language of Actions
        /// </summary>
        public DbSet<MDActionLanguage> ActionLanguages { get; set; }

        /// <summary>
        /// Setting form's languages
        /// </summary>
        public DbSet<MDFormLanguage> FormLanguages { get; set; }

        /// <summary>
        /// All functions of system, to be build menu
        /// </summary>
        public DbSet<MDFunction> Functions { get; set; }

        /// <summary>
        /// Setting Function's Actions
        /// </summary>
        public DbSet<MDFunctionAction> FunctionActions { get; set; }

        /// <summary>
        /// Setting Function's Languages
        /// </summary>
        public DbSet<MDFunctionLanguage> FunctionLanguages { get; set; }

        /// <summary>
        /// Availiable Languages on system
        /// </summary>
        public DbSet<MDLanguage> Languages { get; set; }

        /// <summary>
        /// All Role permission on system
        /// </summary>
        public DbSet<MDRole> Roles { get; set; }

        /// <summary>
        /// Setting Role on functions
        /// </summary>
        public DbSet<MDRoleFunction> RoleFunctions { get; set; }

        /// <summary>
        /// Setting Role on function's Actions
        /// </summary>
        public DbSet<MDRoleFunctionAction> RoleFunctionActions { get; set; }

        /// <summary>
        /// Users login
        /// </summary>
        public DbSet<MDUser> Users { get; set; }

        /// <summary>
        /// User's roles
        /// </summary>
        public DbSet<MDUserRole> UserRoles { get; set; }

        #endregion common

        #region List

        public DbSet<MDGender> Genders { get; set; }

        public DbSet<MDCountry> Countries { get; set; }

        public DbSet<MDProvince> Provinces { get; set; }

        public DbSet<MDDistrict> Districts { get; set; }

        public DbSet<MDWard> Wards { get; set; }

        public DbSet<MDNation> Nations { get; set; }

        public DbSet<MDEducation> Educations { get; set; }

        #endregion List
        public HrisContext(DbContextOptions<HrisContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MDActionLanguage>()
                .HasKey(x => new { x.ActionId, x.LanguageId });

            modelBuilder.Entity<MDFunctionAction>()
                .HasKey(x => new { x.ActionId, x.FunctionId });

            modelBuilder.Entity<MDFunctionLanguage>()
                .HasKey(x => new { x.FunctionId, x.LanguageId});

            modelBuilder.Entity<MDRoleFunction>()
                .HasKey(x => new {x.FunctionId, x.RoleId});

            modelBuilder.Entity<MDRoleFunctionAction>()
                .HasKey(x => new {x.RoleId, x.ActionId, x.FunctionId});

            modelBuilder.Entity<MDUser>()
                .HasIndex(c => c.Username)
                .IsUnique();

            modelBuilder.Entity<MDUserRole>()
                .HasKey(x => new {x.RoleId, x.UserId});

            modelBuilder.Entity<MDFormLanguage>()
                .HasIndex(x => new {x.FunctionId, x.FunctionKey, x.Key, x.LanguageId})
                .IsUnique();
        }
    }
}
