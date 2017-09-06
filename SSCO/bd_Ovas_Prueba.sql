CREATE DATABASE bd_SSCO;

USE bd_SSCO;

/********************************************************/
CREATE TABLE tbl_Usuario(
cedula_Usuario BIGINT PRIMARY KEY NOT NULL,
nombre_Usuario VARCHAR(40) NOT NULL,
apellidos_Usuario VARCHAR(40) NOT NULL,
correo_Usuario VARCHAR(60) NOT NULL,
celular_Usuario VARCHAR(10) NOT NULL
--Cargos
--Cursos
--Módulos
--Reportes
--Indicadores
--Seguimiento Proyecto
);

CREATE TABLE tbl_Posicion(
codigo_Posicion INT PRIMARY KEY IDENTITY NOT NULL,
nombre_Posicion VARCHAR(30) NOT NULL,
documento_Usuario BIGINT NOT NULL,
FOREIGN KEY (documento_Usuario) REFERENCES tbl_Usuario(cedula_Usuario)
);

CREATE TABLE tbl_Cargo(
codigo_Cargo INT PRIMARY KEY IDENTITY NOT NULL,
nombre_Cargo VARCHAR(30) NOT NULL,
descripcion_Cargo VARCHAR(50) NULL,
documento_Usuario BIGINT NOT NULL,
FOREIGN KEY (documento_Usuario) REFERENCES tbl_Usuario(cedula_Usuario)
);

CREATE TABLE tbl_Rol(
--Ejemplo: programador->funcionalidad ova
codigo_Rol INT PRIMARY KEY NOT NULL,
nombre_Rol VARCHAR(30) NOT NULL,
funcion_Rol VARCHAR(100) NULL,
cargo INT NOT NULL,
FOREIGN KEY (cargo) REFERENCES tbl_Cargo(codigo_Cargo)
);

GO
CREATE PROCEDURE llenar_tbl_Posicion(
@nombre VARCHAR(30),
@documento BIGINT
)
AS
BEGIN
IF @nombre='Líder'
BEGIN
INSERT INTO tbl_Posicion (nombre_Posicion, documento_Usuario) VALUES ('Líder', @documento);
END
ELSE IF @nombre='Miembro'
BEGIN
INSERT INTO tbl_Posicion (nombre_Posicion, documento_Usuario) VALUES ('Miembro', @documento);
END
END
GO
GO
CREATE PROCEDURE llenar_tbl_Cargo(
@nombre VARCHAR(30),
@documento BIGINT
)
AS
BEGIN
IF @nombre='Diseñador'
BEGIN
INSERT INTO tbl_Cargo (nombre_Cargo, documento_Usuario) VALUES ('Diseñador', @documento);
END
ELSE IF @nombre='Desarrollador'
BEGIN
INSERT INTO tbl_Cargo (nombre_Cargo, documento_Usuario) VALUES ('Desarrollador', @documento);
END
END
GO
/**************Procedures***************/
GO
CREATE PROCEDURE prc_GuardarCargo(
@codigo INT,
@cargo VARCHAR(30),
@descripcion VARCHAR(50),
@posicion_Cargo VARCHAR(30)
)
AS
BEGIN
INSERT INTO tbl_Usuario (cedula_Usuario, nombre_Usuario, apellidos_Usuario, correo_Usuario, celular_Usuario, rol_Usuario, cargo_Usuario) VALUES(@cedula, @nombre, @apellidos, @correo, @celular, @rol, @cargo);
END
GO
/****************************************************************/
GO
CREATE PROCEDURE prc_GuardarUsuario(
@cedula BIGINT,
@nombre VARCHAR(40),
@apellidos VARCHAR(40),
@correo VARCHAR(60),
@celular VARCHAR(10),
@posicion VARCHAR(10),
@cargo VARCHAR(20)
)
AS
IF @cedula = (SELECT documento_Usuario FROM tbl_Posicion) OR @cedula = (SELECT documento_Usuario FROM tbl_Cargo)
BEGIN
PRINT 'El usuario solo pueden tener un cargo y una posición a la vez'
END
ELSE IF (@posicion = 'Líder' OR @posicion = 'Miembro') AND (@cargo = 'Diseñador' OR @cargo = 'Desarrollador')
BEGIN
PRINT 'Posición correcta'
PRINT 'Cargo correcto'
INSERT INTO tbl_Usuario (cedula_Usuario, nombre_Usuario, apellidos_Usuario, correo_Usuario, celular_Usuario) VALUES(@cedula, @nombre, @apellidos, @correo, @celular);
EXECUTE llenar_tbl_Posicion @posicion,@cedula;
EXECUTE llenar_tbl_Cargo @cargo,@cedula;
END
ELSE
BEGIN
PRINT 'Datos incorrectos' 
END
GO
EXECUTE prc_GuardarUsuario 1017264677, 'Justo Javier', 'Marín Soto',
'miseterjaviermarin@gmail.com', '3122474918', 'Miembro', 'Diseñador'

CREATE PROCEDURE prc_BuscarUsuario(
@cedula BIGINT
)
AS
BEGIN
SELECT * FROM tbl_Usuario WHERE cedula_Usuario = @cedula;
END
GO
GO
CREATE PROCEDURE prc_ModificarUsuario(
@cedula BIGINT,
@nombre VARCHAR(40),
@apellidos VARCHAR(40),
@correo VARCHAR(60),
@celular VARCHAR(10),
@rol VARCHAR(30),
@cargo VARCHAR(30)
)
AS
BEGIN
UPDATE tbl_Usuario SET
nombre_usuario = @nombre, 
apellidos_Usuario = @apellidos,
correo_Usuario = @correo,
celular_Usuario = @celular,
rol_Usuario = @rol,
cargo_Usuario = @cargo
WHERE cedula_Usuario = @cedula;
END
GO
CREATE PROCEDURE prc_EliminarUsuario(
@cedula BIGINT
)
AS
BEGIN
DELETE FROM tbl_Usuario WHERE cedula_Usuario = @cedula;
END
GO
CREATE PROCEDURE prc_ListarUsuarios
AS
BEGIN
SELECT * FROM tbl_Usuario;
END
GO

EXECUTE prc_GuardarUsuario 1017264677, 'Alejandro', 'Marín Jiménez', 'a5606@misena.edu.co',3146843200





CREATE TABLE tbl_Documento(
nombre_Documento VARCHAR(30) NOT NULL,
tipo_Documento VARCHAR(30) NOT NULL,
descripcion_Documento VARCHAR(100) NULL
);

CREATE TABLE tbl_Curso(
nombre_Curso VARCHAR(30) NOT NULL,
modulo_Curso VARCHAR(20) NOT NULL,
duracion_Curso INT NOT NULL,
modalidad_Curso VARCHAR(20) NOT NULL,
nivel_Curso VARCHAR(20) NOT NULL,
temas_Curso INT NULL
--Temas
);