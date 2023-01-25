﻿// <auto-generated />
using System;
using GraphQL.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQL.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230125204355_NullableTypes")]
    partial class NullableTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.Property<Guid>("DevelopersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DevelopersId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("DeveloperProject");
                });

            modelBuilder.Entity("DeveloperProjectItem", b =>
                {
                    b.Property<Guid>("DevelopersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DevelopersId", "ProjectItemsId");

                    b.HasIndex("ProjectItemsId");

                    b.ToTable("DeveloperProjectItem");
                });

            modelBuilder.Entity("GrapgQL.Core.Entities.Developer", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("GrapgQL.Core.Entities.Project", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("GrapgQL.Core.Entities.ProjectItem", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectItems");
                });

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.HasOne("GrapgQL.Core.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrapgQL.Core.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeveloperProjectItem", b =>
                {
                    b.HasOne("GrapgQL.Core.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrapgQL.Core.Entities.ProjectItem", null)
                        .WithMany()
                        .HasForeignKey("ProjectItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrapgQL.Core.Entities.ProjectItem", b =>
                {
                    b.HasOne("GrapgQL.Core.Entities.Project", "Project")
                        .WithMany("ProjectItems")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("GrapgQL.Core.Entities.Project", b =>
                {
                    b.Navigation("ProjectItems");
                });
#pragma warning restore 612, 618
        }
    }
}
