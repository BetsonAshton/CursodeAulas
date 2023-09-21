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
    public class ProfessorMap : IEntityTypeConfiguration<Professor>

    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");

            builder.HasKey(p => p.IdProfessor);

            builder.Property(p => p.IdProfessor)
                .HasColumnName("IDPROFESSOR");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.IdAdm)
               .HasColumnName("IDADM")
               .IsRequired();

            builder.HasOne(p => p.Adm)
                .WithMany(a => a.Professor)
                .HasForeignKey(p => p.IdAdm);

        }
    }
}
