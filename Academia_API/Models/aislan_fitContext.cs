using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Academia_API.Models
{
    public partial class aislan_fitContext : DbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Aluno__8D231D091D250E59");

                entity.ToTable("Aluno");

                entity.Property(e => e.IdAluno).HasColumnName("id_aluno");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.IdAula)
                    .HasName("PK__Aula__B19134FE580EC32D");

                entity.ToTable("Aula");

                entity.Property(e => e.IdAula).HasColumnName("id_aula");

                entity.Property(e => e.CapacidadeMaxima).HasColumnName("capacidade_maxima");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Horario).HasColumnName("horario");

                entity.Property(e => e.IdInstrutor).HasColumnName("id_instrutor");

                entity.Property(e => e.NomeAula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_aula");

                entity.HasOne(d => d.IdInstrutorNavigation)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.IdInstrutor)
                    .HasConstraintName("FK__Aula__id_instrut__38996AB5");
            });

            modelBuilder.Entity<Instrutor>(entity =>
            {
                entity.HasKey(e => e.IdInstrutor)
                    .HasName("PK__Instruto__D670DEA1DD0029F3");

                entity.ToTable("Instrutor");

                entity.Property(e => e.IdInstrutor).HasColumnName("id_instrutor");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Especialidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("especialidade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__Matricul__1D7CF00B6D847D8B");

                entity.ToTable("Matricula");

                entity.Property(e => e.IdMatricula).HasColumnName("id_matricula");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("data_inicio");

                entity.Property(e => e.IdAluno).HasColumnName("id_aluno");

                entity.Property(e => e.PlanoTreinamento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("plano_treinamento");

                entity.Property(e => e.StatusMatricula)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status_matricula");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdAluno)
                    .HasConstraintName("FK__Matricula__id_al__403A8C7D");
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__Presenca__F3BA19A7289CA42F");

                entity.ToTable("Presenca");

                entity.Property(e => e.IdPresenca).HasColumnName("id_presenca");

                entity.Property(e => e.DataAula)
                    .HasColumnType("date")
                    .HasColumnName("data_aula");

                entity.Property(e => e.Horario).HasColumnName("horario");

                entity.Property(e => e.IdAluno).HasColumnName("id_aluno");

                entity.Property(e => e.IdAula).HasColumnName("id_aula");

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
