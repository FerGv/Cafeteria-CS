create database cafeteria;
use cafeteria;

create table usuarios (
	id_usuario	INT NOT NULL AUTO_INCREMENT,
    usuario 	VARCHAR(50) NOT NULL,
	pass 		VARCHAR(50) NOT NULL,
    PRIMARY KEY(id_usuario)
) ENGINE=InnoDB;

create table materia_prima (
	id_materia	INT NOT NULL AUTO_INCREMENT,
    producto 	VARCHAR(50) NOT NULL,
    cantidad 	FLOAT NOT NULL,
	unidad 		VARCHAR(10) NOT NULL,
    precio 		FLOAT NOT NULL,
    stock 		FLOAT NOT NULL,
    PRIMARY KEY(id_materia)
) ENGINE=InnoDB;

INSERT INTO usuarios (usuario, pass) VALUES ('admin', '123');