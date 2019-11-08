using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APITW.Models
{
    public partial class AgendaThoughtWorksContext : DbContext
    {
        public AgendaThoughtWorksContext()
        {
        }

        public AgendaThoughtWorksContext(DbContextOptions<AgendaThoughtWorksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Comunidade> Comunidade { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AgendaThoughtWorks;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2B3E34A8F92C5DD4");

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Administr__IdUsu__412EB0B6");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10DCDD2336");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Comunidade>(entity =>
            {
                entity.HasKey(e => e.IdComunidade)
                    .HasName("PK__Comunida__0BA193C3164D48B9");

                entity.Property(e => e.ContatoComunidade).IsUnicode(false);

                entity.Property(e => e.FotoComunidade).IsUnicode(false);

                entity.Property(e => e.NomeComunidade).IsUnicode(false);

                entity.Property(e => e.NomeResponsavel).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comunidade)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Comunidad__IdUsu__440B1D61");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__Evento__034EFC04830F7BD5");

                entity.Property(e => e.Alimentacao).IsFixedLength();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Libras).IsFixedLength();

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.NomeEvento).IsUnicode(false);

                entity.Property(e => e.Requisicao).IsUnicode(false);

                entity.Property(e => e.RestricaoAlimentacao).IsUnicode(false);

                entity.Property(e => e.Urlsite).IsUnicode(false);

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdAdministrador)
                    .HasConstraintName("FK__Evento__IdAdmini__4CA06362");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evento__IdCatego__4AB81AF0");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdSala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evento__IdSala__4BAC3F29");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evento__IdUsuari__4D94879B");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PK__Funciona__35CB052ADC43A59B");

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Funcionar__IdUsu__3E52440B");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PK__Sala__A04F9B3B0D211002");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B708E8B92");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF975190852E");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105349026D6FB")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuario__7ABB9731A4EBAD2B")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
