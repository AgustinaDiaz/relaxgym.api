INSERT INTO relaxgym_db.roles VALUES(1,'1C777053CC8846E588E6630FFBAFD317', 'Administrador');
INSERT INTO relaxgym_db.roles VALUES(2,'21E7E11C6107494B868386335C0D56ED', 'Entrenador');
INSERT INTO relaxgym_db.roles VALUES(3,'44EDB5595112416EAF42B4E15D845F39', 'Alumno');

INSERT INTO relaxgym_db.estados_usuarios VALUES(1,'80420E3EDB27404BAC11306A5518178A', 'Activo');
INSERT INTO relaxgym_db.estados_usuarios VALUES(2,'9B8E68BB9979424ABC5432A12FC20AF8', 'Inactivo');

INSERT INTO relaxgym_db.usuarios VALUES(1,'EF0A780907E149DEB8FD0E6DFFA367A5', 'Ruben', 'Gomez', 'rg@gmail.com', 3445404040, 'rubeng', 'gomez123', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(2,'DDA5315FFDC64A46B66221FAC7A93A03', 'Carlos', 'Diaz', 'cd@gmail.com', 344428695, 'carlosd', 'diaz123', 2, 3);

SELECT * FROM relaxgym_db.roles;
SELECT * FROM relaxgym_db.estados_usuarios;
SELECT * FROM relaxgym_db.usuarios;