using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Peliculas.Models
{
    public partial class PeliculasContext : DbContext
    {
        public PeliculasContext()
        {
        }

        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-712M2JUF;user=Erika;password=princesa12;database=Peliculas;Persist Security info=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPeliculas);

                entity.Property(e => e.IdPeliculas).HasColumnName("Id_Peliculas");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Publicacion");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Puntuacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
