using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.Models
{
    public partial class LibroAppDBContext : DbContext
    {
        public LibroAppDBContext()
        {
        }

        public LibroAppDBContext(DbContextOptions<LibroAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DLUISDJ;Database=LibroAppDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.AutorId);

                entity.ToTable("autores");

                entity.Property(e => e.AutorId).HasColumnName("autorID");

                entity.Property(e => e.CorreoElectronicoAutor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correoElectronicoAutor");

                entity.Property(e => e.NombreAutor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreAutor");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreCategoria");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.HasKey(e => e.EditorialId);

                entity.ToTable("editoriales");

                entity.Property(e => e.EditorialId).HasColumnName("editorialID");

                entity.Property(e => e.NombreEditorial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEditorial");

                entity.Property(e => e.PaisEditorial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paisEditorial");

                entity.Property(e => e.TelefonoEditorial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefonoEditorial");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("libros");

                entity.Property(e => e.LibroId).HasColumnName("libroID");

                entity.Property(e => e.AnoPublicacionLibro).HasColumnName("anoPublicacionLibro");

                entity.Property(e => e.AutorLibro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("autorLibro");

                entity.Property(e => e.CategoriaLibro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoriaLibro");

                entity.Property(e => e.EditorialLibro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("editorialLibro");

                entity.Property(e => e.NombreLibro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreLibro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
