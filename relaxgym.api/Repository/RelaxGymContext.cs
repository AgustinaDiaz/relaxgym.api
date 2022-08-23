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
        public DbSet<UsuarioNotificacion> UsuariosNotificaciones { get; set; }
        public DbSet<EjercicioRutina> EjerciciosRutinas { get; set; }
        public DbSet<SolicitudCambioPassword> SolicitudesCambioPassword { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<UsuarioTurno> UsuariosTurnos { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<EstadoNotificacion> EstadosNotificaciones { get; set; }
        public DbSet<EstadoUsuario> EstadosUsuarios { get; set; }
        public DbSet<EstadoSolicitud> EstadosSolicitud { get; set; }
        public DbSet<TipoEjercicio> TiposEjercicios { get; set; }
        public DbSet<TipoNotificacion> TiposNotificaciones { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }

        public RelaxGymContext(DbContextOptions<RelaxGymContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitudCambioPassword>().ToTable("solicitudes_cambio_password");
            modelBuilder.Entity<SolicitudCambioPassword>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<SolicitudCambioPassword>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<SolicitudCambioPassword>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<SolicitudCambioPassword>().Property(u => u.FechaSolicitud).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<SolicitudCambioPassword>().Property(u => u.FechaConfirmacion).HasColumnType("datetime");
            modelBuilder.Entity<SolicitudCambioPassword>().Property(u => u.AntiguaClave).HasColumnType("varchar(100)");
            modelBuilder.Entity<SolicitudCambioPassword>().Property(u => u.NuevaClave).HasColumnType("varchar(100)");
            modelBuilder.Entity<SolicitudCambioPassword>().HasOne(e => e.EstadoSolicitud).WithMany().HasForeignKey(p => p.IdEstadoSolicitud).HasConstraintName("FK_SOLICITUDES_CAMBIO_PASSWORD_ESTADOS_SOLICITUDES").IsRequired();
            modelBuilder.Entity<SolicitudCambioPassword>().HasOne(p => p.Usuario).WithMany().HasForeignKey(p => p.IdUsuario).HasConstraintName("FK_SOLICITUDES_CAMBIO_PASSWORD_USUARIOS").IsRequired();

            modelBuilder.Entity<EstadoSolicitud>().ToTable("estados_solicitudes");
            modelBuilder.Entity<EstadoSolicitud>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<EstadoSolicitud>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<EstadoSolicitud>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<EstadoSolicitud>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();

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
            modelBuilder.Entity<Usuario>().Property(u => u.FechaAlta).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.IdEstadoUsuario).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.IdRol).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Usuario>().HasOne(e => e.EstadoUsuario).WithMany().HasForeignKey(p => p.IdEstadoUsuario).HasConstraintName("FK_USUARIOS_ESTADOS_USUARIOS").IsRequired();
            modelBuilder.Entity<Usuario>().HasOne(p => p.Rol).WithMany().HasForeignKey(p => p.IdRol).HasConstraintName("FK_USUARIOS_ROLES").IsRequired();

            modelBuilder.Entity<Rutina>().ToTable("rutinas");
            modelBuilder.Entity<Rutina>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Rutina>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.Descripcion).HasColumnType("varchar(1000)").IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.Nivel).HasColumnType("varchar(45)").IsRequired();
            modelBuilder.Entity<Rutina>().Property(u => u.IdUsuarioCreador).HasColumnType("int").IsRequired();

            modelBuilder.Entity<UsuarioRutina>().ToTable("usuarios_rutinas");
            modelBuilder.Entity<UsuarioRutina>().HasKey(t => new { t.IdUsuario, t.IdRutina });
            modelBuilder.Entity<UsuarioRutina>().Property(u => u.Observacion).HasColumnType("varchar(100)");
            modelBuilder.Entity<UsuarioRutina>().HasOne(pt => pt.Usuario).WithMany(p => p.Rutinas).HasForeignKey(pt => pt.IdUsuario);
            modelBuilder.Entity<UsuarioRutina>().HasOne(pt => pt.Rutina).WithMany(t => t.Usuarios).HasForeignKey(pt => pt.IdRutina);

            modelBuilder.Entity<EjercicioRutina>().ToTable("ejercicios_rutinas");
            modelBuilder.Entity<EjercicioRutina>().HasKey(t => new { t.IdEjercicio, t.IdRutina });
            modelBuilder.Entity<EjercicioRutina>().Property(u => u.CantidadRepeticiones).HasColumnType("int").IsRequired();
            modelBuilder.Entity<EjercicioRutina>().HasOne(pt => pt.Ejercicio).WithMany(p => p.Rutinas).HasForeignKey(pt => pt.IdEjercicio);
            modelBuilder.Entity<EjercicioRutina>().HasOne(pt => pt.Rutina).WithMany(t => t.Ejercicios).HasForeignKey(pt => pt.IdRutina);

            modelBuilder.Entity<Turno>().ToTable("turnos");
            modelBuilder.Entity<Turno>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Turno>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.IdClase).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Turno>().HasOne(p => p.Clase).WithMany().HasForeignKey(p => p.IdClase).HasConstraintName("FK_TURNOS_CLASES").IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.CantidadAlumnos).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Turno>().Property(u => u.Observacion).HasColumnType("varchar(100)");
            modelBuilder.Entity<Turno>().Property(u => u.FechaHora).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<UsuarioTurno>().ToTable("usuarios_turnos");
            modelBuilder.Entity<UsuarioTurno>().HasKey(t => new { t.IdUsuario, t.IdTurno });
            modelBuilder.Entity<UsuarioTurno>().HasOne(pt => pt.Usuario).WithMany(p => p.Turnos).HasForeignKey(pt => pt.IdUsuario);
            modelBuilder.Entity<UsuarioTurno>().HasOne(pt => pt.Turno).WithMany(t => t.Usuarios).HasForeignKey(pt => pt.IdTurno);

            modelBuilder.Entity<UsuarioNotificacion>().ToTable("usuarios_notificaciones");
            modelBuilder.Entity<UsuarioNotificacion>().HasKey(t => new { t.IdUsuario, t.IdNotificacion });
            modelBuilder.Entity<UsuarioNotificacion>().HasOne(pt => pt.Usuario).WithMany(p => p.Notificaciones).HasForeignKey(pt => pt.IdUsuario);
            modelBuilder.Entity<UsuarioNotificacion>().HasOne(pt => pt.Notificacion).WithMany(t => t.Usuarios).HasForeignKey(pt => pt.IdNotificacion);

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
            modelBuilder.Entity<Notificacion>().HasOne(p => p.TipoNotificacion).WithMany().HasForeignKey(p => p.IdTipoNotificacion).HasConstraintName("FK_NOTIFICACIONES_TIPO_NOTIFICACIONES").IsRequired();

            modelBuilder.Entity<TipoEjercicio>().ToTable("tipos_ejercicios");
            modelBuilder.Entity<TipoEjercicio>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<TipoEjercicio>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<TipoEjercicio>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<TipoEjercicio>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();

            modelBuilder.Entity<TipoNotificacion>().ToTable("tipos_notificaciones");
            modelBuilder.Entity<TipoNotificacion>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<TipoNotificacion>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<TipoNotificacion>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<TipoNotificacion>().Property(u => u.Descripcion).HasColumnType("varchar(100)").IsRequired();

            modelBuilder.Entity<Ejercicio>().ToTable("ejercicios");
            modelBuilder.Entity<Ejercicio>().HasKey(u => u.Id).HasName("PRIMARY");
            modelBuilder.Entity<Ejercicio>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.IdWeb).HasColumnType("char(32)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.Nombre).HasColumnType("varchar(1000)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.Descripcion).HasColumnType("varchar(1000)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.UrlEjercicio).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Ejercicio>().Property(u => u.IdTipoEjercicio).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Ejercicio>().HasOne(p => p.TipoEjercicio).WithMany().HasForeignKey(p => p.IdTipoEjercicio).HasConstraintName("FK_EJERCICIOS_TIPOS_EJERCICIOS").IsRequired();
        }
    }
}
