﻿// <auto-generated />
using System;
using Cursos.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cursos.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cursos.Data.Entities.Adm", b =>
                {
                    b.Property<Guid?>("IdAdm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDADM");

                    b.Property<DateTime?>("DataCriacao")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATACRIACAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("SENHA");

                    b.HasKey("IdAdm");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("ADM", (string)null);
                });

            modelBuilder.Entity("Cursos.Data.Entities.Curso", b =>
                {
                    b.Property<Guid?>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDCURSO");

                    b.Property<DateTime?>("Data")
                        .IsRequired()
                        .HasColumnType("date")
                        .HasColumnName("DATA");

                    b.Property<Guid?>("IdAdm")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDADM");

                    b.Property<Guid?>("IdProfessor")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDPROFESSOR");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<decimal?>("Valor")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("VALOR");

                    b.HasKey("IdCurso");

                    b.HasIndex("IdAdm");

                    b.HasIndex("IdProfessor");

                    b.ToTable("CURSO", (string)null);
                });

            modelBuilder.Entity("Cursos.Data.Entities.Professor", b =>
                {
                    b.Property<Guid?>("IdProfessor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDPROFESSOR");

                    b.Property<Guid?>("IdAdm")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDADM");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME");

                    b.HasKey("IdProfessor");

                    b.HasIndex("IdAdm");

                    b.ToTable("Professor", (string)null);
                });

            modelBuilder.Entity("Cursos.Data.Entities.Curso", b =>
                {
                    b.HasOne("Cursos.Data.Entities.Adm", "Adm")
                        .WithMany("Cursos")
                        .HasForeignKey("IdAdm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cursos.Data.Entities.Professor", "Professor")
                        .WithMany("Cursos")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adm");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Cursos.Data.Entities.Professor", b =>
                {
                    b.HasOne("Cursos.Data.Entities.Adm", "Adm")
                        .WithMany("Professor")
                        .HasForeignKey("IdAdm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adm");
                });

            modelBuilder.Entity("Cursos.Data.Entities.Adm", b =>
                {
                    b.Navigation("Cursos");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Cursos.Data.Entities.Professor", b =>
                {
                    b.Navigation("Cursos");
                });
#pragma warning restore 612, 618
        }
    }
}
