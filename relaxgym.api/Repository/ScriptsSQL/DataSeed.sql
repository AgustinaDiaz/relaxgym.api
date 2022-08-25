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

SELECT * FROM relaxgym_db.ejercicios;
INSERT INTO relaxgym_db.ejercicios VALUES(1,'c5b43ff9de194e08bf7215ac5fea70c3', 'Sentadilla', 'Pies apoyados a la anchura de tus caderas con las puntas de los pies hacia delante. No levantar los talones del suelo. Extiende tus brazos hacia delante para darte mayor equilibrio.', 'https://www.youtube.com/embed/upMcew_nvrM', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(2,'af141395bd3343ec819a19f4077c3f94', 'Estocada Frontal', 'Tendras que colocarte de pie, con la espalda recta y dar una zancada hacia adelante mientras la otra pierna desciende llegando con la rodilla casi al suelo. La pierna que da la zancada debe mantener un ángulo de 90 grados durante el descenso.', 'https://www.youtube.com/embed/-df_7H0X7KE', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(3,'34a24418ceff4693b1c5100b4aee71de', 'Estocada con Rotacion', 'Este ejercicio funcional Integra el trabajo de piernas, centro y brazos. Puedes hacerlo con o sin el peso adicional dependiendo tu nivel de entrenamiento', 'https://www.youtube.com/embed/0Xnmo9W7CTU', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(4,'f3ce1e436bee4e71ad365fa766e53915', 'Estocada Lateral', 'En lugar de dar la zancada hacia adelante la daremos hacia un lado y descenderemos mientras realizamos el paso lateral. Es importante mantener la espalda recta e incorporada hacia adelante para que el ejercicio se realice correctamente.', 'https://www.youtube.com/embed/yTRoslfXce0', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(5,'ae81e0f886c34d1399d18f2dea5d1edf', 'Triceps', 'Consiste en sentarse sobre un banco o silla y colocar las manos a los lados, con las palmas hacia abajo. Luego, se debe llevar el cuerpo ligeramente hacia adelante y flexionar los brazos; los glúteos quedan en el aire, ya no en el banco.', 'https://www.youtube.com/embed/HSR_m4uPYOw', 1);
INSERT INTO relaxgym_db.ejercicios VALUES(6,'a5e70a14834c4fe2a0be435b2211f58b', 'Sentadilla Dinamica', 'Puedes escoger diferentes posiciones para tus brazos pero, una vez más, el movimiento y base es el mismo. En este caso habrá una mayor activación de la musculatura debido a que vamos a solicitar a nuestra musculatura un mayor esfuerzo para despegar nuestros pies del suelo en la fase de impulso y para absorber todo el impacto al caer tras la fase de vuelo', 'https://www.youtube.com/embed/fGYeZ5hoQPA', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(7,'eb43a25d86b4432285e29b9e244f0caa', 'Estocada con Salto', 'Sería una estocada estandar pero en lugar de volver a la posición inicial tras el descenso levantariamos y ejecutariamos directamente un salto avanzando asi hacia adelante.', 'https://www.youtube.com/embed/xN4rRRR9NB0', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(8,'d2667f85b8ca48a7a896a883704f2279', 'Estocada Reversa', 'En este tipo olvidaremos la zancada hacia adelante y lo que haremos es llevar la pierna hacia atrás. Ahora las angulaciones son diferentes y trabajaras cuadriceps, gluteos, isquiotibiales y distintos grupos musculares que en la estocada tradicional.', 'https://www.youtube.com/embed/-df_7H0X7KE', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(9,'ec099c08453d4fd298b35d5bf26a49ba', 'Flexiones Saltamontes','Para realizar el ejercicio nos deberemos poner en posición de flexión de brazos con el torso erguido, el trasero levemente levantado, y la punta de los pies y las manos apoyadas en el suelo...', 'https://www.youtube.com/embed/6b0e_VRLMw4', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(10,'729532c34fb64465a98ac158a7537beb', 'Plancha Dinámica','es un ejercicio enfocado a desarrollar la musculatura abdominal. La posición inicial es calcada a la plancha frontal convencional, pero en este caso dejarás de lado la parte isométrica para incorporar un movimiento con la pierna...', 'https://www.youtube.com/embed/585eEjKvrkQ', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(11,'a5bbaf17c0034be58848ede44ccc0334', 'Flexiones de Brazo','Mirando hacia el piso, eleva el cuerpo hasta que los codos formen un ángulo de 90 grados. Luego, empuja el piso, aprieta los glúteos y los músculos del estómago, y levanta el cuerpo hacia arriba para completar una repetición. Debe tomarte un poco más de tiempo bajar que subir....', 'https://www.youtube.com/embed/dH3mlgmvGoM', 1);
INSERT INTO relaxgym_db.ejercicios VALUES(12,'1911e5183ccd4cdcaa639a0479d1f7f3', 'Abdominales con Pelota','Recuéstate con la espalda bien apoyada sobre la colchoneta y las piernas extendidas sujetando la pelota con los tobillos y pantorrillas. Los brazos estirados hacia atrás. Desde esta posición, inhala y, al exhalar, sube el tronco a la vez que elevas las piernas, formando una v....', 'https://www.youtube.com/embed/z_VDVAdAal4', 1);
INSERT INTO relaxgym_db.ejercicios VALUES(13,'576d5f4a254a4134b2414a9cffd0a6fd', 'Abdominales Frontales','Durante la contracción debe dirigir la cabeza hacia las rodillas, no elevarla verticalmente. Cuando alcance la posición más alta, manténgala un mínimo de 1 segundo y baje lentamente después....', 'https://www.youtube.com/embed/5Koa1N021oU', 1);
INSERT INTO relaxgym_db.ejercicios VALUES(14,'a287908d413740fca293fd2df1086c02', 'Escalada','Se trata de un completo ejercicio que combina la plancha isométrica con la elevación de rodillas y que en el que se hace también trabajo aeróbico....', 'https://www.youtube.com/embed/mab1n91GEgw', 3);
INSERT INTO relaxgym_db.ejercicios VALUES(15,'eb3fb45127764d85bb704e18ac99bedf', 'Estocada con Salto', 'Sería una estocada estandar pero en lugar de volver a la posición inicial tras el descenso levantariamos y ejecutariamos directamente un salto avanzando asi hacia adelante..', 'https://www.youtube.com/embed/xN4rRRR9NB0', 2);
INSERT INTO relaxgym_db.ejercicios VALUES(16,'59167afda86a4eceb36e89d6a3ff233c', 'Flexiones de Brazo con rodillas','Túmbese de cara al suelo y coloque sus manos ligeramente más ancho que los hombros mientras aguanta su torso con los brazos extendidos. Aguante su peso con las rodillas y las manos. Mantenga los hombros lejos de las orejas retrayendo las escápulas. Contraiga el suelo pelvico y el core mientras mantiene su cuerpo recto....', 'https://www.youtube.com/embed/AW8Au-K07J0', 3);
INSERT INTO relaxgym_db.ejercicios VALUES(17,'4ee8777761e34eb3ab8a875d976f033b', 'Puente de Glúteos','consiste en un ejercicio centrado en el fortalecimiento de este músculo y de la parte trasera de la pierna. Resulta bastante sencillo de realizar y es apto para personas principiantes. Para incluirlo en tu rutina de fuerza solo necesitarás una esterilla en la que tumbarte....', 'https://www.youtube.com/embed/S0-GNMrJHB4', 3);

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
INSERT INTO relaxgym_db.usuarios VALUES(10,'82f996432bd74c2eb67d465280652ab5', 'Sabrina', 'Viglianco', 'sv@gmail.com', 34445595, 'svig', 'vig123', '20220802', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(11,'29f29008bc0e4f2d83be7aef2edcc640', 'Belen', 'Díaz', 'bd@gmail.com', 3445452689, 'bdiaz', 'maxima159', '20220802', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(12,'9bacad71625940848f52fb0a6084af93', 'Nadia', 'Díaz', 'nd@gmail.com', 3445451579, 'mndiaz', 'male456', '20220802', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(13,'c1856fbd292c4351b3bea7f7d763747c', 'Macarena', 'Marinelli', 'mmarinelli@gmail.com', 341452589, 'mmarinelli', 'maca123', '20220809', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(14,'52ce8ae7899648c5940d41628c6b565a', 'Silvia', 'Stortoni', 'silvia@gmail.com', 341454582, 'silvias', 'stortoni123', '20220809', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(15,'da9fabb4b0464ec3a5201e3210940171', 'Manuel', 'Tortonese', 'torto@gmail.com', 112569359, 'mtortonese', 'manu3220', '20220810', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(16,'aa22808ec2a84bfb9f12b8672bab45a9', 'Enzo', 'Perez', 'enzop@gmail.com', 3415698799, 'eperez', 'enzo789', '20220801', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(17,'181cc196e3f44283b949d9bf56dfb6a7', 'Beltran', 'Carlin', 'beltruc@gmail.com', 343568925, 'bcarlin', 'belt753', '20220729', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(18,'ad391d353c2d48f9ab7357b72067ab1a', 'Bruno', 'Díaz', 'BrunoD@gmail.com', 345692586, 'brudiaz', 'batman159', '20220814', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(19,'06e4607178a04d4983e2272dbd503e3a', 'Mariel', 'Busson', 'mbusson@gmail.com', 3445662089, 'mbusson', 'mariel459', '20220602', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(20,'f7aff67f4136413f95bdd4f463e6f36d', 'Silvia', 'Tapia', 'stapia@gmail.com', 342598756, 'stapia', 'silvita425', '20220202', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(21,'d4c4cb9524cc482494816bf0e905cbc8', 'Luciana', 'Aymar', 'lucha14@gmail.com', 332519689, 'laymar', 'luchaaymar', '20220815', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(22,'c38fa8f9c2d942c88ec4e65f6d5f3b26', 'Juan Luis', 'Guerra', 'Guerra92@gmail.com', 12456754, 'jlguerra', 'bailemos639', '20220102', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(23,'1ce60e5dbc694910963b07827f82c90d', 'Carlos', 'Tevez', 'Carlitosboca@gmail.com', 114518892, 'ctevez', 'boque126', '20220302', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(24,'bc842d49073642b9ac5190fa82ed97d4', 'Micaela', 'Kler', 'micakler@gmail.com', 39032126, 'mkler', 'micagym2015', '20220404', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(25,'4752077b832447d0bac101c55e7d6a88', 'Angela', 'Bernard', 'angBer@gmail.com', 38520666, 'abernard', 'bernard123', '20220520', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(26,'fb0daca0d6164dde8dba399efd3627a5', 'Ezequiel', 'Díaz', 'kolo@gmail.com', 3445451886, 'ediaz', 'kolo123', '20220804', 1, 1);
INSERT INTO relaxgym_db.usuarios VALUES(27,'0c0f5613d0cd4ef08db94cf1007f14e2', 'Carla', 'Rodriguez', 'crodriguez@gmail.com', 114598764, 'crodri', 'rodriguez147', '20220805', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(28,'cb9f29e0138742a49e228aeb8819743a', 'Nazarena', 'Marinelli', 'naza14@gmail.com', 41569555, 'nmarinelli', 'gymrelax456', '20220812', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(29,'ad48ac8fd84645ce9df7cc104b1f1567', 'Camila', 'Marinelli', 'cami1995@gmail.com', 341448962, 'cmarinelli', 'gimnasio2022', '20220112', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(30,'af5749a4fe7d404ba648c9c69dad4c92', 'Agustina', 'Gerk', 'agerk120@gmail.com', 3445405269, 'agerk', 'admin2022', '20220105', 1, 1);
INSERT INTO relaxgym_db.usuarios VALUES(31,'d231b39d56b144fb8834efd4a43fef33', 'Diego', 'Bussanich', 'diego1985@gmail.com', 341263596, 'dbussanich', 'diego123', '20220808', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(32,'eab2d3cd02df4d71ad98bb636b722c54', 'Esteban', 'Gamarra', 'cologamarra@gmail.com', 3445412230, 'egamarra', 'colo2022', '20220809', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(33,'ac7ecf0fb7a840828e0a4d13cbd7cab3', 'Constanza', 'Carballo', 'coos1996@gmail.com', 341445699, 'ccarballo', 'coti123', '20220303', 1, 1);
INSERT INTO relaxgym_db.usuarios VALUES(34,'30b61c75c0e546d48357af84b37b6017', 'Javier', 'Cerbin', 'javic@gmail.com', 342569878, 'jcerbin', 'doc123', '20220622', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(35,'8eb7e89834a345a9b43202438a4f83db', 'Candela', 'Biondi', 'candeb@gmail.com', 3446475869, 'cbiondi', 'model123', '20220715', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(36,'952807a328ac4163aba655fff487ebc0', 'Camila', 'Muñiz', 'cammun@gmail.com', 114456329, 'cmuñiz', 'malaga123', '20220811', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(37,'5f7688b4e8974341bee46894555c4c78', 'Fermin', 'Nara', 'fermin@hotmail.com', 3442690021, 'fnara', 'fer123', '20220818', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(38,'c4c6041d377e49b582f9d8c6e5eff868', 'Baltazar', 'Reyes', 'breyes@hotmail.com', 3269526798, 'breyes', 'balti123', '20220222', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(39,'8c0e957d786a4ff6ad815e7d9e023121', 'Emiliano', 'Rojas', 'emrojas@hotmail.com', 3425695217, 'erojas', 'emi123', '20220617', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(40,'6be5ab3211ea45e9932df4246169bc72', 'Alberto', 'Scavuzzo', 'sca1985@hotmail.com', 11495620, 'ascavuzzo', 'albert123', '20220216', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(41,'f48897902aa04005806a5ffcbb5294b9', 'Marcos', 'Fernandez', 'marcosfernan@hotmail.com', 3445202020, 'mfernandez', 'marquito10', '20220507', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(42,'ef2528be932740b7aff1e18a63aa7560', 'Manuela', 'Albornoz', 'manualbornoz@hotmail.com', 341445988, 'malbornoz', 'manu2015', '20220726', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(43,'5a4feba1e1c6404988be558dae89e014', 'Nadina', 'Bajaroff', 'nadib@hotmail.com', 3445502369, 'nbajaroff', 'nadibajaroff2022', '20220802', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(44,'383a3e6a3bee483fbc74ea07ba108005', 'Yanina', 'Chami', 'yanichami@hotmail.com', 11412577, 'ychami', 'yani123', '20220127', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(45,'d876b43c98e4444f875c59adfcf33cd9', 'Hebe', 'Martinez', 'hebe1988@hotmail.com', 3400402366, 'hmartinez', 'martinez123', '20220809', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(46,'f90c5f373721468f8845ed0327c67713', 'Clara', 'Peralta', 'clarap@hotmail.com', 3445102598, 'cperalta', 'peralta123', '20220730', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(47,'0d9a0cfbb00e415c87b2bea7df23a8f0', 'Pablo', 'Garcia', 'pablitog@hotmail.com', 341484848, 'pgarcia', 'garcia123', '20220404', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(48,'8b892ded22064619b3a7e958197c3894', 'Alba', 'Patronato', 'albapatro@hotmail.com', 343436969, 'apatronato', 'patronato123', '20220628', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(49,'95918fa6e30d4c40b4a43eba2c92d299', 'Mike', 'Ross', 'mikeross@hotmail.com', 343436969, 'apatronato', 'patronato123', '20220628', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(50,'5b570b0a9ce545d4aad92125292728fc', 'Natalia', 'Latorre', 'nlatorre@outlook.com', 3445485012, 'nlatorre', 'latorre123', '20220305', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(51,'efb36fd43b914e52a2eaf99dd5e66cad', 'Ángel', 'Cardozo', 'angcar@outlook.com', 341442266, 'acardozo', 'cardozo123', '20220820', 1, 1);
INSERT INTO relaxgym_db.usuarios VALUES(52,'6e0701877d384b3397769d3c82c32e91', 'Catalina', 'Zapata', 'cataz@outlook.com', 114163200, 'czapata', 'zapata123', '20220320', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(53,'0a230569cefd4d499d186cd17b59d084', 'Jorge', 'Lanata', 'lanataj@outlook.com', 3415267777, 'jlanata', 'lanata123', '20220613', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(54,'c580c16ddbbb49b3bd0a0620ccf63e2a', 'Paula', 'Velez', 'pauv@outlook.com', 342105963, 'pvelez', 'velez123', '20220101', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(55,'ede604037d374870aeae6ddff77ca1f2', 'Ignacio', 'Pratto', 'nachop@outlook.com', 11490001, 'ipratto', 'pratto123', '20220814', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(56,'a1ae852a5ce840c58f91f8500cf1e5b7', 'Vanina', 'Otero', 'vaniot@outlook.com', 341502296, 'votero', 'otero123', '20220814', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(57,'1339d213344743408ae6acc4fa45bb07', 'Daiana', 'Pastoruzzi', 'daip@outlook.com', 3445414155, 'dpastoruzzi', 'pastoruzzi123', '20220722', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(58,'a453ab75de9145c891da9412af53567c', 'Luciano', 'Pignotti', 'cucho@gmail.com', 341435999, 'lpignotti', 'pignotti123', '20220622', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(59,'81cd01a7c7a0405abdc0254bffc37f0f', 'Antonella', 'Rocuzzo', 'antor@gmail.com', 341402396, 'arocuzzo', 'rocuzzo123', '20220430', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(60,'ac581410162b4f1a913c9356212ee39a', 'Lionel', 'Messi', 'pulga@gmail.com', 341402263, 'lmessi', 'messi123', '20220815', 1, 2);
INSERT INTO relaxgym_db.usuarios VALUES(61,'2a9137e71849424981e8946706e5b0ba', 'Martina', 'Garelli', 'gare@gmail.com', 3445417700, 'mgarelli', 'garelli123', '20220228', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(62,'d505c90450444fabbb9b013c1fb0ea3a', 'Jorge', 'Nisman', 'jnis@gmail.com', 11408023, 'jnisman', 'nisman123', '20220319', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(63,'ce8e499be915453893fd8427b94cae1e', 'Samuel', 'Larreta', 'samul@gmail.com', 11500064, 'slarreta', 'larreta123', '20220320', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(64,'58d467694baf423e96b9f1ea800ff261', 'Gerardo', 'Sofovich', 'gerard@gmail.com', 3445662200, 'gsofovich', 'sofovich123', '20220815', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(65,'e29d62bf458947caa79c9ee8f9447bd3', 'Florencia', 'Vigna', 'florvig@gmail.com', 114020365, 'fvigna', 'vigna123', '20220704', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(66,'e1f2c5b4c49046959da710bad94857c8', 'Narda', 'Lepa', 'narditalep@gmail.com', 341209936, 'nlepa', 'lepa123', '20220704', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(67,'55adb774a9f9495f89e5dc54960ca066', 'German', 'Martitegui', 'martiger@gmail.com', 114020036, 'gmartitegui', 'martitegui123', '20220820', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(68,'1acce3abcfcb4578819df9297ab2cf45', 'Manuel', 'Ginobilli', 'manu@gmail.com', 114020036, 'gmartitegui', 'martitegui123', '20220820', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(69,'a1dcbdac4ad04699aab31fa209332aad', 'Laura', 'Woss', 'lauw@gmail.com', 341485009, 'lwoss', 'woss123', '20220402', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(70,'c1fdcdbbf20047b79d4a5d8ab25b2fd3', 'Sebastian', 'Yatra', 'sebayatra@gmail.com', 11630089, 'syatra', 'yatra123', '20220402', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(71,'cdca9e48ddcf4a86aad69fc572435d76', 'Emilia', 'Suarez', 'emisuarez@gmail.com', 3421099632, 'esuarez', 'suarez123', '20220528', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(72,'0b8b40edc1584f89994c6290d04e26b4', 'Daniela', 'Herrero', 'daniH@gmail.com', 3445476239, 'dherrero', 'herrero123', '20220527', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(73,'5e487fdc06b8469db49ed03f75453980', 'Magdalena', 'Edwards', 'magda@gmail.com', 341559034, 'medwards', 'edwards123', '20220527', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(74,'ab509c97048d4e61a177d978aa147951', 'Sonia', 'Ibáñez', 'siba@gmail.com', 3415559034, 'sibañez', 'ibañez123', '20220627', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(75,'37526a9c7d654af78fd020f1a378b255', 'Joaquin', 'Jacob', 'joacojacob@gmail.com', 11491234, 'jjacob', 'jacob123', '20220727', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(76,'db5f43db23bc42d0b3ddb6fd695f96b5', 'Walter', 'Queijeiro', 'walqueij@gmail.com', 3445289631, 'wqueijeiro', 'queijeiro123', '20220727', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(78,'2ee13fb82f2c4f4e8d3f2fc3e313e930', 'Susana', 'Gimenez', 'sug@gmail.com', 11454599, 'sgimenez', 'gimenez123', '20220722', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(79,'e30d9834cba54180bd7d568b1a064b2d', 'Marcelo', 'Tinelli', 'marcetinellig@gmail.com', 11402296, 'mtinelli', 'tinelli123', '20220722', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(80,'c21f51cea7b249c28f049d97cdc3a525', 'Julian', 'Alvarez', 'julialv@gmail.com', 11414177, 'jalvarez', 'alvarez123', '20220712', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(81,'df539773f98545a39b02f5d5e9d03ff7', 'Noel', 'Barrionuevo', 'noebarrionue@gmail.com', 341590236, 'nbarrionuevo', 'barrionuevo123', '20220712', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(82,'f442af2477fe4a69ac6a528a1e032aa8', 'Diego', 'Maradona', 'diegote@gmail.com', 11495502, 'dmaradona', 'maradona123', '20220612', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(83,'0465c7d405c44a9ab568697c440a11e6', 'Kun', 'Aguero', 'kunaguero@gmail.com', 114509632, 'kaguero', 'aguero123', '20220706', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(84,'941c0dc53c244c85953ce1e3a7de0c3d', 'Angel', 'Dimaria', 'fideo2010@gmail.com', 341503369, 'adimaria', 'dimaria123', '20220806', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(85,'c1593a63d207420b81b12be0b09f47ca', 'José Martín', 'Meolans', 'josemeolans@gmail.com', 3445203698, 'jmeolans', 'meolans123', '20220816', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(86,'e3e399bda320441ab1456724cc99005b', 'Santiago', 'Grassi', 'grassiSanti@gmail.com', 34456239577, 'sgrassi', 'grassi123', '20220716', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(87,'897055e29587458abf84698a2e2e601a', 'Guillermo', 'Vilas', 'guilleVilas@gmail.com', 114578963, 'gvilas', 'vilas123', '20220811', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(88,'0983d73a231e4d80b2572bd5e7d26602', 'Paula', 'Pareto', 'lapeque@gmail.com', 3445428596, 'ppareto', 'pareto123', '20220811', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(89,'d614190f64014ed7800cc0a21544639d', 'Juan Manuel', 'Fangio', 'jmfangio2022@gmail.com', 114012365, 'jmfangio', 'fangio123', '20220111', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(90,'2ef5c94ef1a143cf8d5d3187381ba57e', 'Ana', 'Gallay', 'anitagallay@gmail.com', 3414013657, 'agallay', 'gallay123', '20220311', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(91,'10bb3004bc9f45ab9db38f0d95f2803f', 'Facundo', 'Campazzo', 'facucamp@gmail.com', 1140793654, 'fcampazzo', 'campazzo123', '20220811', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(92,'55bb743e491c4d27aa0b13ecbba98302', 'Tania', 'Acosta', 'taniaAcos@gmail.com', 3445102596, 'tacosta', 'acosta123', '20220611', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(93,'14c4af65d3d442b0a84150d1366633bd', 'Agustin', 'Verneci', 'verneciAgus@gmail.com', 342159632, 'averneci', 'verneci123', '20220711', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(94,'01df43718dd84671b2c6aea144eece7d', 'Ramón', 'Quiroga', 'ramonq@gmail.com', 3414012397, 'rquiroga', 'quiroga123', '20220711', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(95,'0a94a23e18c446898e42b7e813038f0c', 'Ignacio', 'Ortiz', 'ignaortiz@gmail.com', 3446529685, 'iortiz', 'ortiz123', '20220211', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(96,'d267a061f83d475db081282c2c63d568', 'Delfina', 'Pignatiello', 'delfpig@gmail.com', 3449526398, 'dpignatiello', 'pignatiello123', '20220211', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(97,'e482cb389f5d4d88acd88c1a6cb94c99', 'Marcos', 'Moneta', 'marquitosm@gmail.com', 3442890036, 'mmoneta', 'moneta123', '20220821', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(98,'fab291eae10a4ffd84844b42a06c7744', 'Leandro', 'Usuna', 'leanusu@gmail.com', 3448524697, 'lusuna', 'usuna123', '20220121', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(99,'71187e709c60415b84f699cead2c325f', 'Lucas', 'Guzmán', 'lucasGuz@gmail.com', 3447850369, 'lguzman', 'guzman123', '20220121', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(100,'9ee5a5cb17a548e2a4469711136631c6', 'Nadia', 'Podoroska ', 'nadiapod@gmail.com', 3448501236, 'npodoroska', 'podoroska123', '20220121', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(101,'49081b11c70444fca07929b39617f45c', 'Fernando', 'Russo', 'russofer@gmail.com', 3443442208, 'frusso', 'russo123', '20220121', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(102,'09e70595ff9a4444bdbe59d95a301a92', 'Diego', 'Schwartzman', 'diegosc@gmail.com', 3443442288, 'dschwartzman', 'schwartzman123', '20220121', 1, 3);
INSERT INTO relaxgym_db.usuarios VALUES(103,'1822c94fe85f4af3a384268e50f153bb', 'Sol', 'Branz', 'solbranz@gmail.com', 3443444188, 'sbranz', 'branz123', '20220821', 1, 3);
 
SELECT * FROM relaxgym_db.usuarios AS U
WHERE U.IDROL=3;

SELECT * FROM relaxgym_db.tipos_ejercicios;
SELECT * FROM relaxgym_db.ejercicios;
SELECT * FROM relaxgym_db.rutinas;
SELECT * FROM relaxgym_db.turnos;
SELECT * FROM relaxgym_db.ejercicios_rutinas;
SELECT * FROM relaxgym_db.usuarios_rutinas;
SELECT * FROM relaxgym_db.usuarios_turnos;
DELETE FROM relaxgym_db.usuarios_turnos WHERE IdUsuario NOT IN (9,32);
SELECT * FROM relaxgym_db.roles;
SELECT * FROM relaxgym_db.estados_usuarios;
SELECT * FROM relaxgym_db.estados_notificaciones;
SELECT * FROM relaxgym_db.usuarios;
SELECT * FROM relaxgym_db.solicitudes_cambio_password;

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