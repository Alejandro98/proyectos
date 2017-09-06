CREATE DATABASE bd_SSCO;
GO
USE bd_SSCO;
GO
/********************************************************/
CREATE TABLE tbl_Usuario(
cedula_Usuario BIGINT PRIMARY KEY NOT NULL,
nombre_Usuario VARCHAR(40) NOT NULL,
apellidos_Usuario VARCHAR(40) NOT NULL,
correo_Usuario VARCHAR(60) NOT NULL,
celular_Usuario VARCHAR(10) NOT NULL,
fecha_Creacion DATETIME NOT NULL
);
CREATE TABLE tbl_Sesion(
usuario BIGINT NOT NULL,
clave VARCHAR(40) NOT NULL,
FOREIGN KEY (usuario) REFERENCES tbl_Usuario (cedula_Usuario)
);
/***********************************************************************************/
CREATE TABLE tbl_Grupo(
codigo_Grupo INT PRIMARY KEY NOT NULL,
nombre_Grupo VARCHAR(30) NOT NULL,
frase_Grupo VARCHAR(30) NOT NULL
);
CREATE TABLE rel_Usuario_Grupo(
documento_Usuario BIGINT NOT NULL,
grupo INT NOT NULL,
alias_Miembro VARCHAR(30) NULL,
FOREIGN KEY (documento_Usuario) REFERENCES tbl_Usuario(cedula_Usuario),
FOREIGN KEY (grupo) REFERENCES tbl_Grupo(codigo_Grupo)
);
/***********************************************************************************/
CREATE TABLE tbl_Profesion(
codigo_Profesion INT PRIMARY KEY NOT NULL,
nombre_Profesion VARCHAR(60) NOT NULL,
descripcion_Profesion VARCHAR(100) NULL
);
CREATE TABLE rel_Usuario_Profesion(
documento_Usuario_P BIGINT NOT NULL,
profesion INT NOT NULL,
FOREIGN KEY (documento_Usuario_P) REFERENCES tbl_Usuario(cedula_Usuario),
FOREIGN KEY (profesion) REFERENCES tbl_Profesion(codigo_Profesion)
);

CREATE TABLE tbl_Rol(
codigo_Rol INT PRIMARY KEY NOT NULL,
nombre_Rol VARCHAR(50) NOT NULL,
descripcion_Rol VARCHAR(100) NULL
);

CREATE TABLE rel_Usuario_Rol(
documento_Usuario_R BIGINT NOT NULL,
rol INT NOT NULL,
FOREIGN KEY (documento_Usuario_R) REFERENCES tbl_Usuario(cedula_Usuario),
FOREIGN KEY (rol) REFERENCES tbl_Rol(codigo_Rol)
);



/***********************************************************************************/
--CREATE TABLE tbl_Entregable(
--codigo_Entregable INT PRIMARY KEY NOT NULL,
--descripcion_Entregable VARCHAR(100) NOT NULL,
--fecha_Entrega DATETIME NOT NULL,
--nombre_Archivo VARCHAR(30) NOT NULL,
----estado_Entregable BIT DEFAULT 0
--);
/***********************************************************************************/
CREATE TABLE tbl_Proyecto(
codigo_Proyecto INT PRIMARY KEY NOT NULL,
nombre_Proyecto VARCHAR(30) NOT NULL,
descripcion_Proyecto VARCHAR(100) NULL
--fase_Desarrollo VARCHAR(20) NOT NULL,--pre,pro-posproduccion
--estado_Proyecto BIT DEFAULT 0,
);

CREATE TABLE rel_Proyecto_Grupo(
proyecto_Grupo INT NOT NULL,
grupo_Proyecto INT NOT NULL,
FOREIGN KEY (proyecto_Grupo) REFERENCES tbl_Proyecto (codigo_Proyecto),
FOREIGN KEY (grupo_Proyecto) REFERENCES tbl_Grupo (codigo_Grupo)
);

CREATE TABLE tbl_EntregaProyecto(
proyecto_Entrega INT NOT NULL,
fecha_Entrega DATETIME NOT NULL,
nombre_Evidencia VARCHAR(30) NOT NULL,
FOREIGN KEY (proyecto_Entrega) REFERENCES tbl_Proyecto (codigo_Proyecto)
);
/***********************************************************************************/
CREATE TABLE tbl_Tarea(
codigo_Tarea INT PRIMARY KEY NOT NULL,
descripcion_Tarea VARCHAR(100) NOT NULL,
duracion_aproximada INT NOT NULL,
fecha_Entrega DATE NOT NULL,
nombre_Archivo VARCHAR(30) NULL
);
CREATE TABLE rel_Usuario_Tarea(
usuario_Tarea BIGINT NOT NULL,
tarea_Usuario INT NOT NULL,
fecha_Tentativa DATETIME NOT NULL,
FOREIGN KEY (usuario_Tarea) REFERENCES tbl_Usuario (cedula_Usuario),
FOREIGN KEY (tarea_Usuario) REFERENCES tbl_Tarea (codigo_Tarea)
);
/***********************************************************************************/
--------CREATE TABLE tbl_FaseDesarrollo(
--------codigo_Fase INT PRIMARY KEY IDENTITY NOT NULL,
--------nombre_Fase VARCHAR(30) NOT NULL,
--------descripcion_Fase VARCHAR(100) NULL,
--------proyecto INT NULL,
--------FOREIGN KEY (proyecto) REFERENCES tbl_Proyecto (codigo_Proyecto)
--------);
----------Tablas de listas desplegables
--------CREATE TABLE tbl_EstadoProyecto(
--------codigo_Estado INT PRIMARY KEY IDENTITY NOT NULL,
--------nombre_Estado VARCHAR(30) NOT NULL,
--------proyecto INT NULL,
--------FOREIGN KEY (proyecto) REFERENCES tbl_Proyecto (codigo_Proyecto)
--------);
/***********************************************************************************/
/***********************************************************************************/
/********************Usuario*********************/