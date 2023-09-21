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
    public class AdmMap : IEntityTypeConfiguration<Adm>

    {
        public void Configure(EntityTypeBuilder<Adm> builder)
        {
            builder.ToTable("ADM");


            builder.HasKey(a => a.IdAdm);


            builder.Property(a => a.IdAdm)
                .HasColumnName("IDADM");

            builder.Property(a => a.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(a => a.Email)
                .IsUnique();

            builder.Property(a => a.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(a => a.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();

        }
    }
}
