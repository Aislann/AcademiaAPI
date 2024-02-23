using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Academia_API.Models
{
    public partial class aislan_fitContext : IdentityDbContext<IdentityUser>
    {
        public aislan_fitContext()
        {
        }

        public aislan_fitContext(DbContextOptions<aislan_fitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<Aula> Aulas { get; set; } = null!;
        public virtual DbSet<Instrutor> Instrutors { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Presenca> Presencas { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Aluno__8D231D091D250E59");

                entity.ToTable("Alunos");

                entity.Property(e => e.IdAluno).HasColumnName("IdAluno");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("DataNascimento");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Endereco");

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Genero");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)

                    .IsUnicode(false)
                    .HasColumnName("Nome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Telefone");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.IdAula)
                    .HasName("PK__Aula__B19134FE580EC32D");

                entity.ToTable("Aulas");

                entity.Property(e => e.IdAula).HasColumnName("IdAula");

                entity.Property(e => e.CapacidadeMaxima).HasColumnName("CapacidadeMaxima");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Descricao");

                entity.Property(e => e.Horario).HasColumnName("Horario");

                entity.Property(e => e.IdInstrutor).HasColumnName("IdInstrutor");

                entity.Property(e => e.NomeAula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NomeAula");

                entity.HasOne(d => d.IdInstrutorNavigation)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.IdInstrutor)
                    .HasConstraintName("FK__Aula__id_instrut__38996AB5");
            });

            modelBuilder.Entity<Instrutor>(entity =>
            {
                entity.HasKey(e => e.IdInstrutor)
                    .HasName("PK__Instruto__D670DEA1DD0029F3");

                entity.ToTable("Instrutors");

                entity.Property(e => e.IdInstrutor).HasColumnName("IdInstrutor");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.Property(e => e.Especialidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Especialidade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Telefone");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__Matricul__1D7CF00B6D847D8B");

                entity.ToTable("Matriculas");

                entity.Property(e => e.IdMatricula).HasColumnName("IdMatricula");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("DataInicio");

                entity.Property(e => e.IdAluno).HasColumnName("IdAluno");

                entity.Property(e => e.PlanoTreinamento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PlanoTreinamento");

                entity.Property(e => e.StatusMatricula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("StatusMatricula");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Matricula__id_al__403A8C7D");
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__Presenca__F3BA19A7289CA42F");

                entity.ToTable("Presencas");

                entity.Property(e => e.IdPresenca).HasColumnName("IdPresenca");

                entity.Property(e => e.DataAula)
                    .HasColumnType("date")
                    .HasColumnName("DataAula");

                entity.Property(e => e.Horario).HasColumnName("Horario");

                entity.Property(e => e.IdAluno).HasColumnName("IdAluno");

                entity.Property(e => e.IdAula).HasColumnName("IdAula");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Presenca__id_alu__44FF419A");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdAula)
                    .HasConstraintName("FK__Presenca__id_aul__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);

        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

