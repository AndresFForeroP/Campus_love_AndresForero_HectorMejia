DROP DATABASE IF EXISTS CampusLove;
CREATE DATABASE IF NOT EXISTS CampusLove;
USE CampusLove;

CREATE TABLE IF NOT EXISTS Genero(
  Id INT NOT NULL AUTO_INCREMENT,
  Genero VARCHAR(25) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Orientacion(
  Id INT NOT NULL AUTO_INCREMENT,
  Orientacion VARCHAR(50) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Busca(
  Id INT NOT NULL AUTO_INCREMENT,
  Busca VARCHAR(100) NOT NULL,
  PRIMARY KEY (Id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Usuarios(
  Id INT NOT NULL AUTO_INCREMENT,
  Nombre VARCHAR(100) NOT NULL,
  Usuario VARCHAR(100) NOT NULL,
  Contraseña VARCHAR(255) NOT NULL,
  Edad INT NOT NULL,
  Id_Genero INT NOT NULL,
  Carrera VARCHAR(40),
  Frase TEXT,
  Id_orientacion INT NOT NULL,
  Id_busca INT NOT NULL,
  PRIMARY KEY (Id),
  CONSTRAINT fk_Busca
    FOREIGN KEY (Id_busca)
    REFERENCES Busca (Id)
    ON DELETE NO ACTION,
  CONSTRAINT fk_Genero
    FOREIGN KEY (Id_Genero)
    REFERENCES Genero (Id)
    ON DELETE NO ACTION,
  CONSTRAINT fk_Orientacion
    FOREIGN KEY (Id_orientacion)
    REFERENCES Orientacion (Id)
    ON DELETE NO ACTION
) ENGINE = InnoDB;






CREATE TABLE IF NOT EXISTS Matches(
  Id_primer_usuario INT NOT NULL,
  Id_segundo_usuario INT NOT NULL,
  PRIMARY KEY (Id_primer_usuario,Id_segundo_usuario),
  CONSTRAINT fk_Primer_Usuario_Match
    FOREIGN KEY (Id_primer_usuario )
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
  CONSTRAINT fk_Segundo_Usuario_Match
    FOREIGN KEY (Id_segundo_usuario)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE
) ENGINE = InnoDB;


CREATE TABLE IF NOT EXISTS Intereses(
  Id INT NOT NULL AUTO_INCREMENT,
  Interes VARCHAR(20) NOT NULL,
  Descripcion TEXT NOT NULL,
  PRIMARY KEY (Id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS InteresesUsuarios(
  Id_usuario INT NOT NULL,
  Id_interes INT NOT NULL,
  PRIMARY KEY (Id_usuario,Id_interes),
  CONSTRAINT fk_Usuarios_Intereses
    FOREIGN KEY (Id_usuario)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
  CONSTRAINT fk_Intereses_Usuario
    FOREIGN KEY (Id_interes)
    REFERENCES Intereses (Id)
    ON DELETE NO ACTION
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Likes(
  Id_usuario_darlike INT NOT NULL,
  Id_usuario_recibirlike INT NOT NULL,
  PRIMARY KEY (Id_usuario_darlike,Id_usuario_recibirlike),
  CONSTRAINT fk_Usuarios_dar_like
    FOREIGN KEY (Id_usuario_darlike)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
  CONSTRAINT fk_Usuarios_recibir_like
    FOREIGN KEY (Id_usuario_recibirlike)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Dislikes(
  Id_usuario_dardislike INT NOT NULL,
  Id_usuario_recibirdislike INT NOT NULL,
  PRIMARY KEY (Id_usuario_dardislike,Id_usuario_recibirdislike),
  CONSTRAINT fk_Usuarios_dar_dislike
    FOREIGN KEY (Id_usuario_dardislike)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
  CONSTRAINT fk_Usuarios_recibir_dislike
    FOREIGN KEY (Id_usuario_recibirdislike)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE
) ENGINE = InnoDB;