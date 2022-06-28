using Microsoft.EntityFrameworkCore;
using relaxgym.api.Entities;

namespace relaxgym.api.Repository
{
    public class RelaxGymContext : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<UsuarioRutina> UsuariosRutinas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<UsuarioTurno> UsuariosTurnos { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<EstadoNotificacion> EstadosNotificaciones { get; set; }
        public DbSet<EstadoUsuario> EstadosUsuarios { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }

        public RelaxGymContext(DbContextOptions<RelaxGymContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EstadoUsuario>().ToTable("estados_usuarios");
            modelBuilder.Entity<EstadoUsuario>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<EstadoUsuario>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<EstadoUsuario>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<EstadoUsuario>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();

            modelBuilder.Entity<Rol>().ToTable("roles");
            modelBuilder.Entity<Rol>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Rol>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Rol>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Rol>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();

            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Usuario>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Apellido).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Email).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Telefono).HasColumnType("decimal(18,0)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.NombreUsuario).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.ClaveUsuario).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.FechaAlta).HasColumnType("datetime(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.IdEstadoUsuario).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.IdRol).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Usuario>().HasOne(e => e.EstadoUsuario).WithMany().HasForeignKey(p => p.IdEstadoUsuario).HasConstraintName("FK_USUARIOS_ESTADOS_USUARIOS").IsRequired();
            modelBuilder.Entity<Usuario>().HasOne(p => p.Rol).WithMany().HasForeignKey(p => p.IdRol).HasConstraintName("FK_USUARIOS_ROLES").IsRequired();

            modelBuilder.Entity<Rutina>().ToTable("rutinas");
            modelBuilder.Entity<Rutina>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Rutina>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.Observacion).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.Nivel).HasColumnType("varchar(45)").IsRequired();

            modelBuilder.Entity<UsuarioRutina>().HasKey(t => new { t.IdUsuario, t.IdRutina });
            modelBuilder.Entity<UsuarioRutina>().HasOne(pt => pt.Usuario).WithMany(p => p.Rutinas).HasForeignKey(pt => pt.IdUsuario);
            modelBuilder.Entity<UsuarioRutina>().HasOne(pt => pt.Rutina).WithMany(t => t.Usuarios).HasForeignKey(pt => pt.IdRutina);

            modelBuilder.Entity<Turno>().ToTable("turnos");
            modelBuilder.Entity<Turno>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Turno>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.IdClase).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Turno>().HasOne(p => p.Clase).WithMany().HasForeignKey(p => p.IdClase).HasConstraintName("FK_TURNOS_CLASES").IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.CantidadAlumnos).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.FechaHora).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<UsuarioTurno>().HasKey(t => new { t.IdUsuario, t.IdTurno });
            modelBuilder.Entity<UsuarioTurno>().HasOne(pt => pt.Usuario).WithMany(p => p.Turnos).HasForeignKey(pt => pt.IdUsuario);
            modelBuilder.Entity<UsuarioTurno>().HasOne(pt => pt.Turno).WithMany(t => t.Usuarios).HasForeignKey(pt => pt.IdTurno);

            modelBuilder.Entity<Clase>().ToTable("clases");
            modelBuilder.Entity<Clase>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Clase>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Clase>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Clase>().Property(u => u.Nombre).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Clase>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();

            modelBuilder.Entity<EstadoNotificacion>().ToTable("estados_notificaciones");
            modelBuilder.Entity<EstadoNotificacion>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<EstadoNotificacion>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<EstadoNotificacion>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<EstadoNotificacion>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();

            modelBuilder.Entity<Notificacion>().ToTable("notificaciones");
            modelBuilder.Entity<Notificacion>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Notificacion>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Notificacion>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Notificacion>().Property(u => u.Titulo).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Notificacion>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Notificacion>().Property(u => u.IdEstadoNotificacion).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Notificacion>().HasOne(p => p.EstadoNotificacion).WithMany().HasForeignKey(p => p.IdEstadoNotificacion).HasConstraintName("FK_NOTIFICACIONES_ESTADOS_NOTIFICACIONES").IsRequired();

            modelBuilder.Entity<Ejercicio>().ToTable("ejercicios");
            modelBuilder.Entity<Ejercicio>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Ejercicio>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.CantidadRepeticiones).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.ImagenEjercicio).HasColumnType("binary(18)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.UrlEjercicio).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.IdTipoEjercicio).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Ejercicio>().HasOne(p => p.TipoEjercicio).WithMany().HasForeignKey(p => p.IdTipoEjercicio).HasConstraintName("FK_EJERCICIOS_TIPOS_EJERCICIOS").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.IdRutina).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Ejercicio>().HasOne(p => p.Rutina).WithMany(x => x.Ejercicios).HasForeignKey(p => p.IdRutina).HasConstraintName("FK_EJERCICIOS_RUTINAS").IsRequired();
        }
    }
}
