CREATE TABLE `clases` (
  `Id` int NOT NULL,
  `IdWeb` char(32) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` varchar(1000) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `ejercicios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdWeb` char(32) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` varchar(1000) NOT NULL,
  `UrlEjercicio` varchar(100) NOT NULL,
  `IdTipoEjercicio` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `FK_EJERCICIOS_TIPOS_EJERCICIOS_idx` (`IdTipoEjercicio`),
  CONSTRAINT `FK_EJERCICIOS_TIPOS_EJERCICIOS` FOREIGN KEY (`IdTipoEjercicio`) REFERENCES `tipos_ejercicios` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `ejercicios_rutinas` (
  `IdEjercicio` int NOT NULL,
  `IdRutina` int NOT NULL,
  `Series` int NOT NULL,
  `CantidadRepeticiones` int NOT NULL,
  PRIMARY KEY (`IdEjercicio`,`IdRutina`),
  KEY `FK_EJERCICIOS_RUTINAS_RUTINAS_idx` (`IdRutina`),
  CONSTRAINT `FK_EJERCICIOS_RUTINAS_EJERCICIOS` FOREIGN KEY (`IdEjercicio`) REFERENCES `ejercicios` (`Id`),
  CONSTRAINT `FK_EJERCICIOS_RUTINAS_RUTINAS` FOREIGN KEY (`IdRutina`) REFERENCES `rutinas` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `estados_notificaciones` (
  `Id` int NOT NULL,
  `IdWeb` char(32) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `estados_solicitudes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdWeb` char(32) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `estados_usuarios` (
  `Id` int NOT NULL,
  `IdWeb` char(32) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `notificaciones` (
  `Id` int NOT NULL,
  `IdWeb` char(32) NOT NULL,
  `Titulo` varchar(100) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `IdEstadoNotificacion` int NOT NULL,
  `IdTipoNotificacion` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`),
  KEY `FK_ESTADOS_NOTIFICACIONES_NOTIFICACIONES_idx` (`IdEstadoNotificacion`),
  CONSTRAINT `FK_NOTIFICACIONES_ESTADOS_NOTIFICACIONES` FOREIGN KEY (`IdEstadoNotificacion`) REFERENCES `estados_notificaciones` (`Id`),
  CONSTRAINT `FK_NOTIFICACIONES_TIPOS_NOTIFICACIONES` FOREIGN KEY (`Id`) REFERENCES `tipos_notificaciones` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `roles` (
  `Id` int NOT NULL,
  `IdWeb` char(32) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `rutinas` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdWeb` char(32) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` varchar(1000) NOT NULL,
  `Nivel` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `solicitudes_cambio_password` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdWeb` char(32) NOT NULL,
  `FechaSolicitud` datetime NOT NULL,
  `FechaConfirmacion` datetime DEFAULT NULL,
  `AntiguaClave` varchar(100) DEFAULT NULL,
  `NuevaClave` varchar(100) DEFAULT NULL,
  `IdEstadoSolicitud` int NOT NULL,
  `IdUsuario` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `FK_SOLICITUDES_CAMBIO_PASSWORD_USUARIOS_idx` (`IdUsuario`),
  KEY `FK_SOLICITUDES_CAMBIO_PASSWORD_ESTADO_SOLICITUDES_idx` (`IdEstadoSolicitud`),
  CONSTRAINT `FK_SOLICITUDES_CAMBIO_PASSWORD_ESTADOS_SOLICITUDES` FOREIGN KEY (`IdEstadoSolicitud`) REFERENCES `estados_solicitudes` (`Id`),
  CONSTRAINT `FK_SOLICITUDES_CAMBIO_PASSWORD_USUARIOS` FOREIGN KEY (`IdUsuario`) REFERENCES `usuarios` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tipos_ejercicios` (
  `Id` int NOT NULL,
  `IdWeb` char(32) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tipos_notificaciones` (
  `Id` int NOT NULL,
  `IdWeb` char(32) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `turnos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdWeb` char(32) NOT NULL,
  `IdClase` int NOT NULL,
  `CantidadAlumnos` int NOT NULL,
  `FechaHora` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`),
  KEY `FK_TURNOS_CLASES_idx` (`IdClase`),
  CONSTRAINT `FK_TURNOS_CLASES` FOREIGN KEY (`IdClase`) REFERENCES `clases` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `usuarios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `IdWeb` char(32) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Telefono` decimal(18,0) NOT NULL,
  `NombreUsuario` varchar(100) NOT NULL,
  `ClaveUsuario` varchar(100) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  `IdEstadoUsuario` int NOT NULL,
  `IdRol` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdWeb_UNIQUE` (`IdWeb`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `FK_USUARIOS_ROLES_idx` (`IdRol`),
  KEY `FK_USUARIOS_ESTADOS_USUARIOS_idx` (`IdEstadoUsuario`),
  CONSTRAINT `FK_USUARIOS_ESTADOS_USUARIOS` FOREIGN KEY (`IdEstadoUsuario`) REFERENCES `estados_usuarios` (`Id`),
  CONSTRAINT `FK_USUARIOS_ROLES` FOREIGN KEY (`IdRol`) REFERENCES `roles` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `usuarios_notificaciones` (
  `IdUsuario` int NOT NULL,
  `IdNotificacion` int NOT NULL,
  PRIMARY KEY (`IdUsuario`,`IdNotificacion`),
  KEY `FK_USUARIOS_NOTIFICACIONES_NOTIFICACIONES_idx` (`IdNotificacion`),
  CONSTRAINT `FK_USUARIOS_NOTIFICACIONES_NOTIFICACIONES` FOREIGN KEY (`IdNotificacion`) REFERENCES `notificaciones` (`Id`),
  CONSTRAINT `FK_USUARIOS_NOTIFICACIONES_USUARIOS` FOREIGN KEY (`IdUsuario`) REFERENCES `usuarios` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `usuarios_rutinas` (
  `IdUsuario` int NOT NULL,
  `IdRutina` int NOT NULL,
  `Observacion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`,`IdRutina`),
  KEY `FK_USUARIOS_RUTINAS_RUTINAS_idx` (`IdRutina`),
  CONSTRAINT `FK_USUARIOS_RUTINAS_RUTINAS` FOREIGN KEY (`IdRutina`) REFERENCES `rutinas` (`Id`),
  CONSTRAINT `FK_USUARIOS_RUTINAS_USUARIOS` FOREIGN KEY (`IdUsuario`) REFERENCES `usuarios` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `usuarios_turnos` (
  `IdUsuario` int NOT NULL,
  `IdTurno` int NOT NULL,
  PRIMARY KEY (`IdUsuario`,`IdTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;