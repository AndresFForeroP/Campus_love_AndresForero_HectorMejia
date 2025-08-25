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

INSERT INT Usuarios(Nombre,Usuario,Contraseña,Edad,Id_Genero,Carrera,Frase,Id_orientacion,Id_busca) VALUES
('María','Maria',"Maria",22,4,'Ingeniera de Sistemas','Buscando bugs en corazones 💻❤️',4,4 ),
('Juan','Juan','Juan',24,3,'Diseñador Grafico','Un match y te diseño el futuro 🎨',2,2),
('Laura','Laura','Laura',24,5,'Lectura','Te escucho con el corazón ☕📚',7,3),
('Carlos','Carlos','Carlos',23,1,'Medicina','El mejor remedio: una buena cita 🩺🍿',1,1),
('Andrea','Andrea','Andrea',22,1,'Derecho','Argumenta tu amor 💼✈️',4,1),
('Luis','Luis','Luis',25,2,'Administracion','Invertir en amor	 la mejor decisión 💰♟️',4,7);
