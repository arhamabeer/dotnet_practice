﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_mvc.Models;

#nullable disable

namespace dotnet_mvc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230407093907_photoPathAdded")]
    partial class photoPathAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dotnet_mvc.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("department")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("photoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            id = 1,
                            department = 3,
                            email = "arham@gmail.com",
                            name = "Arham"
                        },
                        new
                        {
                            id = 2,
                            department = 4,
                            email = "arham@abeer.com",
                            name = "Abeer"
                        },
                        new
                        {
                            id = 3,
                            department = 0,
                            email = "ahmed@aaa.com",
                            name = "Ahmed"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}