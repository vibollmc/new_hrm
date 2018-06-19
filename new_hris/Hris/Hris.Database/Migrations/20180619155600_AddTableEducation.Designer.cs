﻿// <auto-generated />
using System;
using Hris.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hris.Database.Migrations
{
    [DbContext(typeof(HrisContext))]
    [Migration("20180619155600_AddTableEducation")]
    partial class AddTableEducation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hris.Database.Entities.Common.MDAction", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Event")
                        .HasMaxLength(50);

                    b.Property<string>("Icon")
                        .HasMaxLength(50);

                    b.Property<string>("Key")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Order");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDActionLanguage", b =>
                {
                    b.Property<int?>("ActionId");

                    b.Property<int?>("LanguageId");

                    b.Property<string>("Name");

                    b.HasKey("ActionId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ActionLanguages");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDFormLanguage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<int?>("FunctionId");

                    b.Property<string>("FunctionKey")
                        .HasMaxLength(50);

                    b.Property<string>("Key")
                        .HasMaxLength(50);

                    b.Property<int?>("LanguageId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Value")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("FunctionId", "FunctionKey", "Key", "LanguageId")
                        .IsUnique()
                        .HasFilter("[FunctionId] IS NOT NULL AND [FunctionKey] IS NOT NULL AND [Key] IS NOT NULL AND [LanguageId] IS NOT NULL");

                    b.ToTable("FormLanguages");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDFunction", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Icon")
                        .HasMaxLength(50);

                    b.Property<string>("Key")
                        .HasMaxLength(50);

                    b.Property<int>("Module");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("OrderIndex");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDFunctionAction", b =>
                {
                    b.Property<int?>("ActionId");

                    b.Property<int?>("FunctionId");

                    b.HasKey("ActionId", "FunctionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("FunctionActions");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDFunctionLanguage", b =>
                {
                    b.Property<int?>("FunctionId");

                    b.Property<int?>("LanguageId");

                    b.Property<string>("Name");

                    b.HasKey("FunctionId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("FunctionLanguages");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDLanguage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDRole", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDRoleFunction", b =>
                {
                    b.Property<int?>("FunctionId");

                    b.Property<int?>("RoleId");

                    b.HasKey("FunctionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleFunctions");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDRoleFunctionAction", b =>
                {
                    b.Property<int?>("RoleId");

                    b.Property<int?>("ActionId");

                    b.Property<int?>("FunctionId");

                    b.HasKey("RoleId", "ActionId", "FunctionId");

                    b.HasIndex("ActionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("RoleFunctionActions");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDUser", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<string>("DateFormat")
                        .HasMaxLength(20);

                    b.Property<string>("DecimalSymbol")
                        .HasMaxLength(1);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("DigitGroupingSymbol")
                        .HasMaxLength(1);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Fullname")
                        .HasMaxLength(50);

                    b.Property<string>("IpAddress")
                        .HasMaxLength(50);

                    b.Property<string>("LanguageCode")
                        .HasMaxLength(10);

                    b.Property<int?>("LanguageId");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<string>("TimeFormat")
                        .HasMaxLength(10);

                    b.Property<int?>("TimeZone");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDUserRole", b =>
                {
                    b.Property<int?>("RoleId");

                    b.Property<int?>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Hris.Database.Entities.List.MDCountry", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Hris.Database.Entities.List.MDDistrict", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<int?>("ProvinceId");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Hris.Database.Entities.List.MDEducation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Hris.Database.Entities.List.MDGender", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Hris.Database.Entities.List.MDNation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("Hris.Database.Entities.List.MDProvince", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Hris.Database.Entities.List.MDWard", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(20);

                    b.Property<int?>("DistrictId");

                    b.Property<string>("Name");

                    b.Property<string>("NameEn");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDActionLanguage", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDAction", "Action")
                        .WithMany("ActionLanguages")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hris.Database.Entities.Common.MDLanguage", "Language")
                        .WithMany("ActionLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDFormLanguage", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDFunction", "Function")
                        .WithMany("FormLanguages")
                        .HasForeignKey("FunctionId");

                    b.HasOne("Hris.Database.Entities.Common.MDLanguage", "Language")
                        .WithMany("FormLanguages")
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDFunctionAction", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDAction", "Action")
                        .WithMany("FunctionActions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hris.Database.Entities.Common.MDFunction", "Function")
                        .WithMany("FunctionActions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDFunctionLanguage", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDFunction", "Function")
                        .WithMany("FunctionLanguages")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hris.Database.Entities.Common.MDLanguage", "Language")
                        .WithMany("FunctionLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDRoleFunction", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDFunction", "Function")
                        .WithMany("RoleFunctions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hris.Database.Entities.Common.MDRole", "Role")
                        .WithMany("RoleFunctions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDRoleFunctionAction", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDAction", "Action")
                        .WithMany("RoleFunctionActions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hris.Database.Entities.Common.MDFunction", "Function")
                        .WithMany("RoleFunctionActions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hris.Database.Entities.Common.MDRole", "Role")
                        .WithMany("RoleFunctionActions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDUser", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDLanguage", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("Hris.Database.Entities.Common.MDUserRole", b =>
                {
                    b.HasOne("Hris.Database.Entities.Common.MDRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hris.Database.Entities.Common.MDUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
