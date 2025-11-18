using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoVozCode.Models;

namespace ProjetoVozCode.Contexts;

public partial class vozCodeContext : DbContext
{
    public vozCodeContext()
    {
    }

    public vozCodeContext(DbContextOptions<vozCodeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arquivo> Arquivos { get; set; }

    public virtual DbSet<Execusao> Execusaos { get; set; }

    public virtual DbSet<Linguagem> Linguagems { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=vozCode;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arquivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Arquivo__3213E83FBB339F8B");

            entity.ToTable("Arquivo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataModificacao)
                .HasColumnType("datetime")
                .HasColumnName("Data_modificacao");
            entity.Property(e => e.LinguagemId).HasColumnName("Linguagem_id");
            entity.Property(e => e.NomeArquivo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nome_arquivo");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Linguagem).WithMany(p => p.Arquivos)
                .HasForeignKey(d => d.LinguagemId)
                .HasConstraintName("FK__Arquivo__Linguag__4D94879B");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Arquivos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Arquivo__Usuario__4E88ABD4");
        });

        modelBuilder.Entity<Execusao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Execusao__3213E83F637163E2");

            entity.ToTable("Execusao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArquivoId).HasColumnName("Arquivo_id");
            entity.Property(e => e.ErroTerminal)
                .HasColumnType("text")
                .HasColumnName("erro_terminal");
            entity.Property(e => e.SaidaTerminal)
                .HasColumnType("text")
                .HasColumnName("saida_terminal");

            entity.HasOne(d => d.Arquivo).WithMany(p => p.Execusaos)
                .HasForeignKey(d => d.ArquivoId)
                .HasConstraintName("FK__Execusao__Arquiv__5165187F");
        });

        modelBuilder.Entity<Linguagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Linguage__3213E83F17404657");

            entity.ToTable("Linguagem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Linguagem1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Linguagem");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FE4FF79D8");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
