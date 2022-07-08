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

SELECT * FROM relaxgym_db.roles;
SELECT * FROM relaxgym_db.estados_usuarios;
SELECT * FROM relaxgym_db.usuarios;
SELECT * FROM relaxgym_db.solicitudes_cambio_password;

DELETE FROM relaxgym_db.usuarios
WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12);

DELETE FROM relaxgym_db.roles
WHERE Id IN (1, 2, 3);

DELETE FROM relaxgym_db.estados_usuarios
WHERE Id IN (1, 2);