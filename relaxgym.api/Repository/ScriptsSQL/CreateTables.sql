CREATE TABLE clases (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Nombre] varchar(100) NOT NULL,
  [Descripcion] varchar(1000) NOT NULL,
  [Imagen] varbinary(max) NOT NULL
  PRIMARY KEY ([Id])
);

CREATE TABLE estados_notificaciones (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Descripcion] varchar(100) NOT NULL,
  PRIMARY KEY ([Id])
);

CREATE TABLE estados_solicitudes (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Descripcion] varchar(100) NOT NULL,
  PRIMARY KEY ([Id])
);

CREATE TABLE estados_usuarios (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Descripcion] varchar(100) NOT NULL,
  PRIMARY KEY ([Id])
);

CREATE TABLE roles (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Descripcion] varchar(100) NOT NULL,
  PRIMARY KEY ([Id])
);

CREATE TABLE rutinas (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Nombre] varchar(100) NOT NULL,
  [Descripcion] varchar(1000) NOT NULL,
  [Nivel] varchar(45) NOT NULL,
  [IdUsuarioCreador] int NOT NULL,
  PRIMARY KEY ([Id])
);

CREATE TABLE tipos_ejercicios (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Descripcion] varchar(100) NOT NULL,
  PRIMARY KEY ([Id])
);

CREATE TABLE tipos_notificaciones (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Descripcion] varchar(100) NOT NULL,
  PRIMARY KEY ([Id])
);

CREATE TABLE turnos (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [IdClase] int NOT NULL,
  [CantidadAlumnos] int NOT NULL,
  [Observacion] varchar(100) NULL,
  [FechaHora] datetime2(0) NOT NULL,
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_TURNOS_CLASES] FOREIGN KEY ([IdClase]) REFERENCES clases ([Id])
);

CREATE TABLE usuarios (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Nombre] varchar(100) NOT NULL,
  [Apellido] varchar(100) NOT NULL,
  [Email] varchar(100) NOT NULL,
  [Telefono] decimal(18,0) NOT NULL,
  [NombreUsuario] varchar(100) NOT NULL,
  [ClaveUsuario] varchar(100) NOT NULL,
  [FechaAlta] datetime2(0) NOT NULL,
  [IdEstadoUsuario] int NOT NULL,
  [IdRol] int NOT NULL,
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_USUARIOS_ESTADOS_USUARIOS] FOREIGN KEY ([IdEstadoUsuario]) REFERENCES estados_usuarios ([Id]),
  CONSTRAINT [FK_USUARIOS_ROLES] FOREIGN KEY ([IdRol]) REFERENCES roles ([Id])
);

CREATE INDEX [FK_USUARIOS_ROLES_idx] ON usuarios ([IdRol]);
CREATE INDEX [FK_USUARIOS_ESTADOS_USUARIOS_idx] ON usuarios ([IdEstadoUsuario]);

CREATE TABLE solicitudes_cambio_password (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [FechaSolicitud] datetime2(0) NOT NULL,
  [FechaConfirmacion] datetime2(0) DEFAULT NULL,
  [AntiguaClave] varchar(100) DEFAULT NULL,
  [NuevaClave] varchar(100) DEFAULT NULL,
  [IdEstadoSolicitud] int NOT NULL,
  [IdUsuario] int NOT NULL,
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_SOLICITUDES_CAMBIO_PASSWORD_ESTADOS_SOLICITUDES] FOREIGN KEY ([IdEstadoSolicitud]) REFERENCES estados_solicitudes ([Id]),
  CONSTRAINT [FK_SOLICITUDES_CAMBIO_PASSWORD_USUARIOS] FOREIGN KEY ([IdUsuario]) REFERENCES usuarios ([Id])
);

CREATE INDEX [FK_SOLICITUDES_CAMBIO_PASSWORD_USUARIOS_idx] ON solicitudes_cambio_password ([IdUsuario]);
CREATE INDEX [FK_SOLICITUDES_CAMBIO_PASSWORD_ESTADO_SOLICITUDES_idx] ON solicitudes_cambio_password ([IdEstadoSolicitud]);

CREATE TABLE notificaciones (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Titulo] varchar(100) NOT NULL,
  [Descripcion] varchar(100) NOT NULL,
  [IdEstadoNotificacion] int NOT NULL,
  [IdTipoNotificacion] int NOT NULL,
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_NOTIFICACIONES_ESTADOS_NOTIFICACIONES] FOREIGN KEY ([IdEstadoNotificacion]) REFERENCES estados_notificaciones ([Id]),
  CONSTRAINT [FK_NOTIFICACIONES_TIPOS_NOTIFICACIONES] FOREIGN KEY ([Id]) REFERENCES tipos_notificaciones ([Id])
);

CREATE INDEX [FK_ESTADOS_NOTIFICACIONES_NOTIFICACIONES_idx] ON notificaciones ([IdEstadoNotificacion]);

CREATE TABLE ejercicios (
  [Id] int NOT NULL IDENTITY,
  [IdWeb] char(32) NOT NULL,
  [Nombre] varchar(100) NOT NULL,
  [Descripcion] varchar(1000) NOT NULL,
  [UrlEjercicio] varchar(100) NOT NULL,
  [IdTipoEjercicio] int NOT NULL,
  PRIMARY KEY ([Id]),
  CONSTRAINT [FK_EJERCICIOS_TIPOS_EJERCICIOS] FOREIGN KEY ([IdTipoEjercicio]) REFERENCES tipos_ejercicios ([Id])
);

CREATE INDEX [FK_EJERCICIOS_TIPOS_EJERCICIOS_idx] ON ejercicios ([IdTipoEjercicio]);

CREATE TABLE usuarios_notificaciones (
  [IdUsuario] int NOT NULL,
  [IdNotificacion] int NOT NULL,
  PRIMARY KEY ([IdUsuario],[IdNotificacion]),
  CONSTRAINT [FK_USUARIOS_NOTIFICACIONES_NOTIFICACIONES] FOREIGN KEY ([IdNotificacion]) REFERENCES notificaciones ([Id]),
  CONSTRAINT [FK_USUARIOS_NOTIFICACIONES_USUARIOS] FOREIGN KEY ([IdUsuario]) REFERENCES usuarios ([Id])
);

CREATE INDEX [FK_USUARIOS_NOTIFICACIONES_NOTIFICACIONES_idx] ON usuarios_notificaciones ([IdNotificacion]);

CREATE TABLE ejercicios_rutinas (
  [IdEjercicio] int NOT NULL,
  [IdRutina] int NOT NULL,
  [Series] int NOT NULL,
  [CantidadRepeticiones] int NOT NULL,
  PRIMARY KEY ([IdEjercicio],[IdRutina]),
  CONSTRAINT [FK_EJERCICIOS_RUTINAS_EJERCICIOS] FOREIGN KEY ([IdEjercicio]) REFERENCES ejercicios ([Id]),
  CONSTRAINT [FK_EJERCICIOS_RUTINAS_RUTINAS] FOREIGN KEY ([IdRutina]) REFERENCES rutinas ([Id])
);

CREATE INDEX [FK_EJERCICIOS_RUTINAS_RUTINAS_idx] ON ejercicios_rutinas ([IdRutina]);

CREATE TABLE usuarios_rutinas (
  [IdUsuario] int NOT NULL,
  [IdRutina] int NOT NULL,
  [Observacion] varchar(100) DEFAULT NULL,
  PRIMARY KEY ([IdUsuario],[IdRutina]),
  CONSTRAINT [FK_USUARIOS_RUTINAS_RUTINAS] FOREIGN KEY ([IdRutina]) REFERENCES rutinas ([Id]),
  CONSTRAINT [FK_USUARIOS_RUTINAS_USUARIOS] FOREIGN KEY ([IdUsuario]) REFERENCES usuarios ([Id])
);

CREATE INDEX [FK_USUARIOS_RUTINAS_RUTINAS_idx] ON usuarios_rutinas ([IdRutina]);

CREATE TABLE usuarios_turnos (
  [IdUsuario] int NOT NULL,
  [IdTurno] int NOT NULL,
  PRIMARY KEY ([IdUsuario],[IdTurno])
);