DROP DATABASE CampusLove;
CREATE DATABASE IF NOT EXISTS CampusLove;
USE CampusLove


CREATE TABLE IF NOT EXISTS Usuarios(
  Id INT NOT NULL AUTO_INCREMENT,
  Nombre VARCHAR(100) NOT NULL,
  Edad INT NOT NULL,
  Genero VARCHAR(20) NOT NULL,
  Carrera VARCHAR(40),
  Frase TEXT,
  PRIMARY KEY (Id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Intereses(
  Id INT NOT NULL AUTO_INCREMENT,
  Interes VARCHAR(20) NOT NULL,
  Descripcion TEXT NOT NULL,
  PRIMARY KEY (Id)
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS InteresesUsuarios(
  Id_usuarios INT NOT NULL AUTO_INCREMENT,
  Id_intereses VARCHAR(20) NOT NULL
  PRIMARY KEY (Id_usuarios,Id_intereses),
  CONSTRAINT fk_Usuarios
    FOREIGN KEY (Id_usuarios)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
  CONSTRAINT fk_Intereses
    FOREIGN KEY (Id_intereses)
    REFERENCES Interes (Id)
    ON DELETE CASCADE
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Likes(
  Id_usuario_dar INT NOT NULL,
  Id_usuario_recibir INT NOT NULL,
  PRIMARY KEY (Id_usuario_dar,Id_usuario_recibir)
  CONSTRAINT fk_Usuarios_dar_like
    FOREIGN KEY (Id_usuarios_dar)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
  CONSTRAINT fk_Usuarios_recibir_like
    FOREIGN KEY (Id_usuarios_recibir)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
) ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS Dislikes(
  Id_usuario_dar INT NOT NULL,
  Id_usuario_recibir INT NOT NULL,
  PRIMARY KEY (Id_usuario_dar,Id_usuario_recibir)
  CONSTRAINT fk_Usuarios_dar_like
    FOREIGN KEY (Id_usuarios_dar)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
  CONSTRAINT fk_Usuarios_recibir_like
    FOREIGN KEY (Id_usuarios_recibir)
    REFERENCES Usuarios (Id)
    ON DELETE CASCADE,
) ENGINE = InnoDB;