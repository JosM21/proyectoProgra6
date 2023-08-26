using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyectoProgra6.Models
{
    public partial class proyectoProgra6_1Context : DbContext
    {
        public proyectoProgra6_1Context()
        {
        }

        public proyectoProgra6_1Context(DbContextOptions<proyectoProgra6_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteViaje> ClienteViajes { get; set; } = null!;
        public virtual DbSet<Hospedaje> Hospedajes { get; set; } = null!;
        public virtual DbSet<Itinerario> Itinerarios { get; set; } = null!;
        public virtual DbSet<Recorrido> Recorridos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioRol> UsuarioRols { get; set; } = null!;
        public virtual DbSet<Viaje> Viajes { get; set; } = null!;
        public virtual DbSet<Vuelo> Vuelos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("SERVER=.; DATABASE=proyectoProgra6_1; INTEGRATED SECURITY=FALSE; USER ID=proyectoProgra6_1APIUser; PASSWORD=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__885457EEE5CEE360");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaNacimiento)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.IsBlocked)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<ClienteViaje>(entity =>
            {
                entity.HasKey(e => e.IdClienteViaje);

                entity.ToTable("ClienteViaje");

                entity.Property(e => e.IdClienteViaje)
                    .ValueGeneratedNever()
                    .HasColumnName("idClienteViaje");

                entity.Property(e => e.FkCliente).HasColumnName("fkCliente");

                entity.Property(e => e.FkViaje).HasColumnName("fkViaje");

                entity.HasOne(d => d.FkClienteNavigation)
                    .WithMany(p => p.ClienteViajes)
                    .HasForeignKey(d => d.FkCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClienteVi__fkCli__5629CD9C");

                entity.HasOne(d => d.FkViajeNavigation)
                    .WithMany(p => p.ClienteViajes)
                    .HasForeignKey(d => d.FkViaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClienteVi__fkVia__571DF1D5");
            });

            modelBuilder.Entity<Hospedaje>(entity =>
            {
                entity.HasKey(e => e.IdHotel)
                    .HasName("PK__Hospedaj__AE924C1CB1D97396");

                entity.ToTable("Hospedaje");

                entity.Property(e => e.IdHotel).HasColumnName("idHotel");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IsBlocked)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NombreHotel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombreHotel");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");
            });

            modelBuilder.Entity<Itinerario>(entity =>
            {
                entity.HasKey(e => e.IdItinerario);

                entity.ToTable("Itinerario");

                entity.Property(e => e.IdItinerario)
                    .ValueGeneratedNever()
                    .HasColumnName("idItinerario");

                entity.Property(e => e.FkRecorrido).HasColumnName("fkRecorrido");

                entity.Property(e => e.FkViaje).HasColumnName("fkViaje");

                entity.HasOne(d => d.FkRecorridoNavigation)
                    .WithMany(p => p.Itinerarios)
                    .HasForeignKey(d => d.FkRecorrido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Itinerari__fkRec__4F7CD00D");

                entity.HasOne(d => d.FkViajeNavigation)
                    .WithMany(p => p.Itinerarios)
                    .HasForeignKey(d => d.FkViaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Itinerari__fkVia__5070F446");
            });

            modelBuilder.Entity<Recorrido>(entity =>
            {
                entity.HasKey(e => e.IdRecorrido)
                    .HasName("PK__Recorrid__9D3E255E7CFE8ED5");

                entity.ToTable("Recorrido");

                entity.Property(e => e.IdRecorrido).HasColumnName("idRecorrido");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CostoPp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("costoPP");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fecha");

                entity.Property(e => e.HoraSalida)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("horaSalida");

                entity.Property(e => e.IsBlocked)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Lugar)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lugar");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6480D42A4");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.BackUpEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("backUpEmail");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(1500)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FkUsuarioRol).HasColumnName("fkUsuarioRol");

                entity.Property(e => e.IsBlocked)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.UsuarioRol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.FkUsuarioRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__fkUsuar__3B75D760");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioRol)
                    .HasName("PK__UsuarioR__50B0920764796AB5");

                entity.ToTable("UsuarioRol");

                entity.Property(e => e.IdUsuarioRol).HasColumnName("idUsuarioRol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(e => e.IdViaje)
                    .HasName("PK__Viaje__CFFF2BF03CB0E00E");

                entity.ToTable("Viaje");

                entity.Property(e => e.IdViaje).HasColumnName("idViaje");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Costo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("costo");

                entity.Property(e => e.Destino)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("destino");

                entity.Property(e => e.FechaRegreso)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fechaRegreso");

                entity.Property(e => e.FechaSalida)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fechaSalida");

                entity.Property(e => e.FkHospedaje).HasColumnName("fkHospedaje");

                entity.Property(e => e.IsBlocked)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.FkHospedajeNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.FkHospedaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Viaje__fkHospeda__440B1D61");

            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IdVuelo)
                    .HasName("PK__Vuelo__8FC0EFB77EA0C1B9");

                entity.ToTable("Vuelo");

                entity.Property(e => e.IdVuelo).HasColumnName("idVuelo");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Aerolinea)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("aerolinea");

                entity.Property(e => e.Destino)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("destino");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fecha");

                entity.Property(e => e.FkViaje).HasColumnName("fkViaje");

                entity.Property(e => e.Gate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("gate");

                entity.Property(e => e.HoraAterrizaje)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("horaAterrizaje");

                entity.Property(e => e.HoraDespegue)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("horaDespegue");

                entity.Property(e => e.IsBlocked)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.FkViajeNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.FkViaje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vuelo__fkViaje__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
