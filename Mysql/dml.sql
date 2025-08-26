INSERT INTO Genero (Genero) VALUES
('Hombre Cisgénero'),
('Hombre Intersexual'),
('Hombre Trans'),
('Mujer Cisgénero'),
('Mujer Intersexual'),
('Mujer Trans'),
('Mas allá del binario');

INSERT INTO Orientacion (Orientacion) VALUES
('Heterosexual'),
('Gay u homosexual'),
('Lesbiana'),
('Bisexual'),
('Asexual'),
('Demisexual'),
('Pansexual'),
('Queer'),
('Explorando'),
('Arromantico'),
('Omnisexual'),
('Otro');

INSERT INTO Busca (Busca) VALUES
('Relacion'),
('Relacion, pero no me cierro'),
('Diversion, pero no me cierro'),
('Diversion a corto plazo'),
('Hacer amigos'),
('Lo sigo pensando');

INSERT Usuarios(Nombre,Usuario,Contraseña,Edad,Id_Genero,Carrera,Frase,Id_orientacion,Id_busca) VALUES
('María','Maria','Maria',22,4,'Ingeniera de Sistemas','Buscando bugs en corazones 💻❤️',4,4 ),
('Juan','Juan','Juan',24,3,'Diseñador Grafico','Un match y te diseño el futuro 🎨',2,2),
('Laura','Laura','Laura',24,5,'Lectura','Te escucho con el corazón ☕📚',7,3),
('Carlos','Carlos','Carlos',23,1,'Medicina','El mejor remedio: una buena cita 🩺🍿',1,1),
('Andrea','Andrea','Andrea',22,1,'Derecho','Argumenta tu amor 💼✈️',4,1),
('Luis','Luis','Luis',25,2,'Administracion','Invertir en amor la mejor decisión 💰♟️',4,5);

INSERT INTO Intereses (Interes, Descripcion) VALUES
('Música', 'Gusto por la música, asistir a conciertos, escuchar diferentes géneros'),
('Deportes', 'Actividades físicas, ver partidos, practicar deportes'),
('Cine', 'Pasión por el cine, ver películas, series y documentales'),
('Viajar', 'Conocer nuevos lugares, culturas y vivir aventuras'),
('Leer', 'Disfrutar de la lectura de libros, revistas, etc.'),
('Cocina', 'Preparar y degustar diferentes platillos, explorar la gastronomía'),
('Videojuegos', 'Jugar en consolas, PC o móviles'),
('Arte', 'Gusto por la pintura, escultura, teatro, etc.'),
('Naturaleza', 'Explorar la naturaleza, hacer senderismo, acampar'),
('Programación', 'Crear código, desarrollar software, aprender nuevos lenguajes'),
('Fotografía', 'Capturar momentos, paisajes y personas');

INSERT INTO InteresesUsuarios (Id_usuario, Id_interes) VALUES
(1, 4), 
(1, 5), 
(1, 10), 
(2, 8), 
(2, 3), 
(3, 5), 
(3, 9), 
(4, 2), 
(4, 6),
(5, 4), 
(5, 5), 
(6, 6), 
(6, 7); 

INSERT INTO Likes (Id_usuario_darlike, Id_usuario_recibirlike) VALUES
(1, 2), 
(2, 1), 
(3, 4), 
(4, 3), 
(5, 6), 
(6, 5); 

INSERT INTO Dislikes (Id_usuario_dardislike, Id_usuario_recibirdislike) VALUES
(1, 3), 
(2, 4), 
(3, 1), 
(4, 2); 


INSERT INTO Matches (Id_primer_usuario, Id_segundo_usuario) VALUES
(1, 2),
(3, 4),
(5, 6);
