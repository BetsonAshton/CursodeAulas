using Cursos.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Data.Mappings
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("CURSO");

            builder.HasKey(c => c.IdCurso);

            builder.Property(c => c.IdCurso)
                .HasColumnName("IDCURSO");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(c => c.Data)
                .HasColumnName("DATA")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.IdProfessor)
                .HasColumnName("IDPROFESSOR")
                .IsRequired();

            builder.Property(c => c.IdAdm)
               .HasColumnName("IDADM")
               .IsRequired();

            builder.HasOne(c => c.Professor)
                .WithMany(c => c.Cursos)
                .HasForeignKey(c => c.IdProfessor);

            builder.HasOne(c => c.Adm)
                .WithMany(u => u.Cursos)
                .HasForeignKey(c => c.IdAdm);
        }
    }
}
