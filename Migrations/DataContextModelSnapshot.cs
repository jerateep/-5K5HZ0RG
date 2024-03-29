﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppCore.Data;

namespace WebAppCore.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppCore.Models.TBL_Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("DepId");

                    b.ToTable("TBL_Department");
                });

            modelBuilder.Entity("WebAppCore.Models.TBL_Salary", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Dtm_Pay")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SId");

                    b.HasIndex("UserId");

                    b.ToTable("TBL_Salary");
                });

            modelBuilder.Entity("WebAppCore.Models.TBL_User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("DepId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.HasIndex("DepId");

                    b.ToTable("TBL_User");
                });

            modelBuilder.Entity("WebAppCore.Models.TBL_Salary", b =>
                {
                    b.HasOne("WebAppCore.Models.TBL_User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAppCore.Models.TBL_User", b =>
                {
                    b.HasOne("WebAppCore.Models.TBL_Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepId");

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
