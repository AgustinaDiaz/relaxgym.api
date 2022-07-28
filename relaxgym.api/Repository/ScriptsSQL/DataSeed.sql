INSERT INTO relaxgym_db.tipos_ejercicios VALUES(1,'497eec999630475687785c1dba62c01a', 'Brazos');
INSERT INTO relaxgym_db.tipos_ejercicios VALUES(2,'a253e03e0ae74af6a6b347447bc10972', 'Piernas');
INSERT INTO relaxgym_db.tipos_ejercicios VALUES(3,'302349dab90c4c699d8945dac22a477a', 'Gluteos');
INSERT INTO relaxgym_db.tipos_ejercicios VALUES(4,'97bf0f83d4f04805a7b35f9548119bfd', 'Abdomen');

INSERT INTO relaxgym_db.tipos_notificaciones VALUES(1,'84840de3a6194df988476a3f8792981e', 'General');
INSERT INTO relaxgym_db.tipos_notificaciones VALUES(2,'9c643cbf50694f30948e2d6725b6dd19', 'Particular');

INSERT INTO relaxgym_db.estados_notificaciones VALUES(1,'715018527475450f9b38ef0fcecee77b', 'Enviada');
INSERT INTO relaxgym_db.estados_notificaciones VALUES(2,'859c803b8d60491f804ef7dffc992b20', 'Leida');

INSERT INTO relaxgym_db.clases VALUES(1,'d2bcacfb94714642980aa1583686b3b7', 'Crossfit', 'Es un metodo de entrenamiento basado en ejercicios constantemente variados, con movimientos funcionales ejecutados a alta intensidad. Es un entrenamiento basado en los ejercicios de cuerpos militares, policiales y de bomberos.');
INSERT INTO relaxgym_db.clases VALUES(2,'3553bb420f5b4eeebad4cf1f5adcb116', 'Funcional', 'El entrenamiento funcional se basa en realizar ejercicios que se adaptan a los movimientos naturales del cuerpo humano para trabajar de forma global músculos y articulaciones.');

INSERT INTO relaxgym_db.turnos VALUES(1,'d2bcacfb94714642980aa1583686b3b7', 1, 30, '2022-07-20 10:30:00');
INSERT INTO relaxgym_db.turnos VALUES(2,'3553bb420f5b4eeebad4cf1f5adcb116', 2, 20, '2022-07-20 11:00:00');
INSERT INTO relaxgym_db.turnos VALUES(3,'46085f48c46844c294b69ff2258ed43c', 1, 30, '2022-07-21 09:30:00');
INSERT INTO relaxgym_db.turnos VALUES(4,'225441491599491da81912a77f3ae29c', 2, 20, '2022-07-21 13:00:00');
INSERT INTO relaxgym_db.turnos VALUES(5,'f499895f5a084b4dad91174fc08b3391', 2, 2, '2022-07-19 09:00:00');
INSERT INTO relaxgym_db.turnos VALUES(6,'0ee6ceb6fa3a4c38aad9202aeaefdd80', 1, 3, '2022-07-19 08:00:00');
INSERT INTO relaxgym_db.turnos VALUES(7,'4a6742f001624d37a44458209e182f0f', 1, 30, '2022-07-22 07:00:00');
INSERT INTO relaxgym_db.turnos VALUES(8,'c8313808318e45d599d3f567bc2e01b7', 2, 20, '2022-07-22 08:00:00');

INSERT INTO relaxgym_db.usuarios_turnos VALUES(3,5);
INSERT INTO relaxgym_db.usuarios_turnos VALUES(7,5);
INSERT INTO relaxgym_db.usuarios_turnos VALUES(3,6);
INSERT INTO relaxgym_db.usuarios_turnos VALUES(7,6);

INSERT INTO relaxgym_db.ejercicios VALUES(1,'c5b43ff9de194e08bf7215ac5fea70c3', 'Sentadilla', 'Pies apoyados a la anchura de tus caderas con las puntas de los pies hacia delante. No levantar los talones del suelo. Extiende tus brazos hacia delante para darte mayor equilibrio.', 'https://www.youtube.com/embed/upMcew_nvrM', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(2,'af141395bd3343ec819a19f4077c3f94', 'Estocada Frontal', 'Tendras que colocarte de pie, con la espalda recta y dar una zancada hacia adelante mientras la otra pierna desciende llegando con la rodilla casi al suelo. La pierna que da la zancada debe mantener un ángulo de 90 grados durante el descenso.', 'https://www.youtube.com/embed/-df_7H0X7KE', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(3,'34a24418ceff4693b1c5100b4aee71de', 'Estocada con Rotacion', 'Este ejercicio funcional Integra el trabajo de piernas, centro y brazos. Puedes hacerlo con o sin el peso adicional dependiendo tu nivel de entrenamiento', 'https://www.youtube.com/embed/0Xnmo9W7CTU', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(4,'f3ce1e436bee4e71ad365fa766e53915', 'Estocada Lateral', 'En lugar de dar la zancada hacia adelante la daremos hacia un lado y descenderemos mientras realizamos el paso lateral. Es importante mantener la espalda recta e incorporada hacia adelante para que el ejercicio se realice correctamente.', 'https://www.youtube.com/embed/yTRoslfXce0', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(5,'ae81e0f886c34d1399d18f2dea5d1edf', 'Triceps', 'Consiste en sentarse sobre un banco o silla y colocar las manos a los lados, con las palmas hacia abajo. Luego, se debe llevar el cuerpo ligeramente hacia adelante y flexionar los brazos; los glúteos quedan en el aire, ya no en el banco.', 'https://www.youtube.com/embed/HSR_m4uPYOw', 1);
INSERT INTO relaxgym_db.ejercicios VALUES(6,'a5e70a14834c4fe2a0be435b2211f58b', 'Sentadilla Dinamica', 'Puedes escoger diferentes posiciones para tus brazos pero, una vez más, el movimiento y base es el mismo. En este caso habrá una mayor activación de la musculatura debido a que vamos a solicitar a nuestra musculatura un mayor esfuerzo para despegar nuestros pies del suelo en la fase de impulso y para absorber todo el impacto al caer tras la fase de vuelo', 'https://www.youtube.com/embed/fGYeZ5hoQPA', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(7,'eb43a25d86b4432285e29b9e244f0caa', 'Estocada con Salto', 'Sería una estocada estandar pero en lugar de volver a la posición inicial tras el descenso levantariamos y ejecutariamos directamente un salto avanzando asi hacia adelante.', 'https://www.youtube.com/embed/xN4rRRR9NB0', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(8,'d2667f85b8ca48a7a896a883704f2279', 'Estocada Reversa', 'En este tipo olvidaremos la zancada hacia adelante y lo que haremos es llevar la pierna hacia atrás. Ahora las angulaciones son diferentes y trabajaras cuadriceps, gluteos, isquiotibiales y distintos grupos musculares que en la estocada tradicional.', 'https://www.youtube.com/embed/-df_7H0X7KE', 2);

INSERT INTO relaxgym_db.rutinas VALUES(1, '1fea337717ec4cffa3255de7ac328b48', 'Piernas: Sin Peso', 'El entrenamiento de pierna es clave para transformar el cuerpo, ya sea para perder grasa o para ganar volumen. Un entrenamiento enfocado en el tren inferior significa que más de la mitad de tu cuerpo va a estar trabajando durante ese entrenamiento.', 'Bajo');
INSERT INTO relaxgym_db.rutinas VALUES(2, 'e58eccdee8b042c7982603385b2c7e64', 'Piernas: Con Peso', 'El entrenamiento de pierna es clave para transformar el cuerpo, ya sea para perder grasa o para ganar volumen. Un entrenamiento enfocado en el tren inferior significa que más de la mitad de tu cuerpo va a estar trabajando durante ese entrenamiento.', 'Alto');

INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(1, 1, 4, 20);
INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(2, 1, 2, 10);
INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(3, 1, 2, 10);
INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(4, 1, 2, 10);

INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(1, 2, 4, 10);
INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(2, 2, 2, 5);
INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(3, 2, 2, 5);
INSERT INTO relaxgym_db.ejercicios_rutinas VALUES(4, 2, 2, 5);

INSERT INTO relaxgym_db.roles VALUES(1,'daaa56ea94ba4b9ea7c6f078be7990da', 'Administrador');
INSERT INTO relaxgym_db.roles VALUES(2,'ba69a7c1cfeb4ed7a40ef7b017e4e0a3', 'Entrenador');
INSERT INTO relaxgym_db.roles VALUES(3,'f5a3d570f40f4ae9acb1161038a24d16', 'Alumno');

INSERT INTO relaxgym_db.estados_usuarios VALUES(1,'9d57cd37e86842f088dbc918a2ac6f27', 'Activo');
INSERT INTO relaxgym_db.estados_usuarios VALUES(2,'a79be5515363423c964ee3875471fb97', 'Inactivo');

INSERT INTO relaxgym_db.estados_solicitudes VALUES(1,'b685cba76a544ef8aa21c091844fa748', 'Activo');
INSERT INTO relaxgym_db.estados_solicitudes VALUES(2,'8c271acc8ddc46ca9555b7bef647ee68', 'Finalizado');

INSERT INTO relaxgym_db.usuarios VALUES(1,'d63ca7480aab4f5c89c27d2223bdbb2b', 'Agustina', 'Diaz', 'ag@gmail.com', 3589658423, 'adiaz', 'diaz123', '20220101', 1, 1);
INSERT INTO relaxgym_db.usuarios VALUES(2,'592a526d45774dea9db24cd6dbeb48ec', 'Juan Andres', 'Viglianco', 'jv@gmail.com', 3364340196, 'jviglianco', 'viglianco123', '20220105', 1, 1);
INSERT INTO relaxgym_db.usuarios VALUES(3,'3c07e9dfbce344a2a89cb5673580ae89', 'Ruben', 'Gomez', 'rg@gmail.com', 3445404040, 'rgomez', 'gomez123', '20220203', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(4,'1e08be56a12641c8ae724c371525a63f', 'Mauro', 'Pincolini', 'mp@gmail.com', 3358562131, 'mpincolini', 'pincolini123', '20220215', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(5,'b3ca0134345d4f2a964fdc11f559c483', 'Agustina', 'Reyes', 'ar@gmail.com', 33698451325, 'areyes', 'reyes123', '20220323', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(6,'d7cd12f0c1774c1f869d34e8a28438e8', 'Matias', 'Albala', 'ma@gmail.com', 33912354984, 'malbala', 'albala123', '20220324', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(7,'69e10fd3e5a944d99235aa01b5963d6f', 'Florencia', 'Anderson', 'fa@gmail.com', 51654866, 'fanderson', 'anderson123', '20220325', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(8,'ed5b1147f7d24ccaaca47823fc52d6b4', 'Jeremias', 'Ramb', 'jr@gmail.com', 3364859663, 'jramb', 'ramb123', '20220519', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(9,'7e9e6e99235343adbf3a32242e855a5a', 'Carlos', 'Diaz', 'cd@gmail.com', 344428695, 'cdiaz', 'diaz123', '20220627', 1, 2);

SELECT * FROM relaxgym_db.tipos_ejercicios;
SELECT * FROM relaxgym_db.ejercicios;
SELECT * FROM relaxgym_db.rutinas;
SELECT * FROM relaxgym_db.turnos;
SELECT * FROM relaxgym_db.ejercicios_rutinas;
SELECT * FROM relaxgym_db.usuarios_rutinas;
SELECT * FROM relaxgym_db.usuarios_turnos;
SELECT * FROM relaxgym_db.roles;
SELECT * FROM relaxgym_db.estados_usuarios;
SELECT * FROM relaxgym_db.estados_notificaciones;
SELECT * FROM relaxgym_db.usuarios;
SELECT * FROM relaxgym_db.solicitudes_cambio_password;

DELETE FROM relaxgym_db.ejercicios_rutinas
WHERE IdRutina = 2 AND IdEjercicio IN (1,2,3,4);

DELETE FROM relaxgym_db.usuarios
WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12);

DELETE FROM relaxgym_db.rutinas
WHERE Id IN (1, 2);

DELETE FROM relaxgym_db.turnos
WHERE Id IN (1,2,3,4,5,6,7,8);

DELETE FROM relaxgym_db.ejercicios_rutinas
WHERE IdEjercicio IN (1);

DELETE FROM relaxgym_db.roles
WHERE Id IN (1, 2, 3);

DELETE FROM relaxgym_db.estados_usuarios
WHERE Id IN (1, 2);

DELETE FROM relaxgym_db.ejercicios
WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8);