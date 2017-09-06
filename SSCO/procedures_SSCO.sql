GO
USE bd_SSCO;
GO
/********************Usuario*********************/
CREATE PROCEDURE prc_GuardarUsuario(
@cedula BIGINT,
@nombre VARCHAR(40),
@apellidos VARCHAR(40),
@correo VARCHAR(60),
@celular VARCHAR(10),
@profesion INT,
@rol INT
)
AS
BEGIN
IF EXISTS (SELECT cedula_Usuario FROM tbl_Usuario WHERE cedula_Usuario = @cedula)
BEGIN
PRINT 'El usuario ya existe'
END
ELSE IF (NOT EXISTS (SELECT codigo_Rol FROM tbl_Rol)) OR  (NOT EXISTS(SELECT codigo_Profesion FROM tbl_Profesion))
BEGIN
PRINT 'No existen roles o profesiones en la base de datos'
END
ELSE
INSERT INTO tbl_Usuario (cedula_Usuario, nombre_Usuario, apellidos_Usuario, correo_Usuario, celular_Usuario, fecha_Creacion) VALUES(@cedula, @nombre, @apellidos, @correo, @celular, GETDATE()); 
INSERT INTO rel_Usuario_Profesion(documento_Usuario_P, profesion) VALUES(@cedula, @profesion);
INSERT INTO rel_Usuario_Rol(documento_Usuario_R, rol) VALUES(@cedula, @rol);
END
GO
GO
CREATE PROCEDURE prc_BuscarUsuario(
@cedula BIGINT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Usuario WHERE cedula_Usuario=@cedula)
BEGIN
PRINT 'El usuario no existe'
END
ELSE
BEGIN
SELECT nombre_Usuario,apellidos_Usuario,correo_Usuario,celular_Usuario,
codigo_Profesion, codigo_Rol FROM tbl_Usuario
INNER JOIN rel_Usuario_Profesion ON documento_Usuario_P = cedula_Usuario
INNER JOIN tbl_Profesion ON profesion = codigo_Profesion
INNER JOIN rel_Usuario_Rol ON documento_Usuario_R = cedula_Usuario
INNER JOIN tbl_Rol ON rol = codigo_Rol
WHERE cedula_Usuario = @cedula;
END
END
GO
GO
CREATE PROCEDURE prc_ModificarUsuario(
@cedula BIGINT,
@nombre VARCHAR(40),
@apellidos VARCHAR(40),
@correo VARCHAR(60),
@celular VARCHAR(10),
@profesion INT,
@rol INT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Usuario WHERE cedula_Usuario=@cedula)
BEGIN
PRINT 'El usuario no existe'
END
ELSE
BEGIN
UPDATE tbl_Usuario SET
nombre_Usuario = @nombre,
apellidos_Usuario = @apellidos,
correo_Usuario = @correo,
celular_Usuario = @celular
WHERE cedula_Usuario = @cedula;
UPDATE rel_Usuario_Profesion SET
profesion = @profesion
WHERE documento_Usuario_P = @cedula;
UPDATE rel_Usuario_Rol SET
rol = @rol
WHERE documento_Usuario_R = @cedula;
END
END
GO
GO
CREATE PROCEDURE prc_EliminarUsuario(
@cedula BIGINT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Usuario WHERE cedula_Usuario=@cedula)
BEGIN
PRINT 'El usuario no existe'
END
ELSE
BEGIN
DELETE FROM rel_Usuario_Profesion WHERE documento_Usuario_P = @cedula;
DELETE FROM rel_Usuario_Rol WHERE documento_Usuario_R = @cedula;
DELETE FROM rel_Usuario_Grupo WHERE documento_Usuario = @cedula;
DELETE FROM tbl_Usuario WHERE cedula_Usuario = @cedula;
END
END
GO
GO
CREATE PROCEDURE prc_ListarUsuarios
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Usuario)
BEGIN
PRINT 'No existen usuarios'
END
ELSE
BEGIN
SELECT tbl_Usuario.*,nombre_Profesion,nombre_Rol FROM tbl_Usuario
INNER JOIN rel_Usuario_Profesion ON documento_Usuario_P = cedula_Usuario
INNER JOIN tbl_Profesion ON profesion = codigo_Profesion
INNER JOIN rel_Usuario_Rol ON documento_Usuario_R = cedula_Usuario
INNER JOIN tbl_Rol ON rol = codigo_Rol;
END
END
GO
/********************Profesión*********************/
GO
CREATE PROCEDURE prc_GuardarProfesion(
@cod_prof INT,--Obligatorio
@nom_prof VARCHAR(60),--Obligatorio
@desc_prof VARCHAR(100)
)
AS
BEGIN
IF EXISTS (SELECT codigo_Profesion FROM tbl_Profesion WHERE codigo_Profesion = @cod_prof)
BEGIN
PRINT 'La profesión ya existe'
END
ELSE
BEGIN
INSERT INTO tbl_Profesion (codigo_Profesion, nombre_Profesion, descripcion_Profesion)
VALUES (@cod_prof, @nom_prof,@desc_prof);
END
END
GO
GO
CREATE PROCEDURE prc_BuscarProfesion(
@cod_prof INT--Obligatorio
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Profesion WHERE codigo_Profesion=@cod_prof)
BEGIN
PRINT 'La profesión no existe'
END
ELSE
BEGIN
SELECT * FROM tbl_Profesion WHERE codigo_Profesion = @cod_prof;
END
END
GO
GO
CREATE PROCEDURE prc_ModificarProfesion(
@cod_prof INT,--Obligatorio
@nom_prof VARCHAR(60),--Obligatorio
@desc_prof VARCHAR(100)
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Profesion WHERE codigo_Profesion=@cod_prof)
BEGIN
PRINT 'La profesion no existe'
END
ELSE
BEGIN
UPDATE tbl_Profesion SET 
nombre_Profesion = @nom_prof,
descripcion_Profesion = @desc_prof
WHERE codigo_Profesion = @cod_prof;
END
END
GO
GO
CREATE PROCEDURE prc_EliminarProfesion(
@cod_prof INT--Obligatorio
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Profesion WHERE codigo_Profesion=@cod_prof)
BEGIN
PRINT 'La profesión no existe'
END
ELSE
BEGIN
DELETE FROM tbl_Profesion WHERE codigo_Profesion = @cod_prof;
END
END
GO
GO
CREATE PROCEDURE prc_ListarProfesiones
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Profesion)
BEGIN
PRINT 'No existen profesiones'
END
ELSE
BEGIN
SELECT * FROM tbl_Profesion;
END
END
GO

/********************Rol*********************/
GO
CREATE PROCEDURE prc_GuardarRol(
@cod_rol INT,
@nom_rol VARCHAR(50),
@desc_rol VARCHAR(100)
)
AS
BEGIN
IF @cod_rol = (SELECT codigo_Rol FROM tbl_Rol WHERE codigo_Rol = @cod_rol)
BEGIN
PRINT 'El rol ya existe'
END
ELSE
BEGIN
INSERT INTO tbl_Rol (codigo_Rol, nombre_Rol, descripcion_Rol)
VALUES (@cod_rol, @nom_rol,@desc_rol);
END
END
GO
GO
CREATE PROCEDURE prc_BuscarRol(
@cod_rol INT--Obligatorio
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Rol WHERE codigo_Rol=@cod_rol)
BEGIN
PRINT 'El rol no existe'
END
ELSE
BEGIN
SELECT * FROM tbl_Rol WHERE codigo_Rol = @cod_rol;
END
END
GO
GO
CREATE PROCEDURE prc_ModificarRol(
@cod_rol INT,
@nom_rol VARCHAR(50),
@desc_rol VARCHAR(100)
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Rol WHERE codigo_Rol=@cod_rol)
BEGIN
PRINT 'El rol no existe'
END
ELSE
BEGIN
UPDATE tbl_Rol SET 
nombre_Rol = @nom_rol,
descripcion_Rol = @desc_rol
WHERE codigo_Rol = @cod_rol;
END
END
GO
GO
CREATE PROCEDURE prc_EliminarRol(
@cod_rol INT--Obligatorio
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Rol WHERE codigo_Rol=@cod_rol)
BEGIN
PRINT 'El rol no existe'
END
ELSE
BEGIN
DELETE FROM tbl_Rol WHERE codigo_Rol = @cod_rol;
END
END
GO
GO
CREATE PROCEDURE prc_ListarRoles
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Rol)
BEGIN
PRINT 'No existen roles'
END
ELSE
BEGIN
SELECT * FROM tbl_Rol;
END
END
GO
/********************Asignar Miembro*********************/
GO
CREATE PROCEDURE prc_AsignarMiembro(
@cedula BIGINT,
@cod_grupo INT,
@alias VARCHAR(30)
)
AS
BEGIN
IF EXISTS (SELECT documento_Usuario FROM rel_Usuario_Grupo WHERE documento_Usuario = @cedula)
BEGIN
PRINT 'El miembro ya fue asignado a un grupo'
END
ELSE
BEGIN
INSERT INTO rel_Usuario_Grupo (documento_Usuario, grupo, alias_Miembro)
VALUES (@cedula, @cod_grupo, @alias);
END
END
GO
GO
CREATE PROCEDURE prc_BuscarMiembro(
@cedula INT--Obligatorio
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM rel_Usuario_Grupo WHERE documento_Usuario=@cedula)
BEGIN
PRINT 'El miembro no existe'
END
ELSE
BEGIN
SELECT documento_Usuario,codigo_Grupo,alias_Miembro FROM tbl_Grupo
INNER JOIN rel_Usuario_Grupo ON grupo = codigo_Grupo
INNER JOIN tbl_Usuario ON documento_Usuario = cedula_Usuario
WHERE cedula_Usuario = @cedula;
END
END
GO
GO
CREATE PROCEDURE prc_ModificarMiembro(
@cedula BIGINT,
@cod_grupo INT,
@alias VARCHAR(30)
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM rel_Usuario_Grupo WHERE documento_Usuario=@cedula)
BEGIN
PRINT 'El miembro no existe'
END
ELSE
BEGIN
UPDATE rel_Usuario_Grupo SET 
grupo = @cod_grupo,
alias_Miembro = @alias
WHERE documento_Usuario = @cedula;
END
END
GO
GO
CREATE PROCEDURE prc_EliminarMiembro(
@cedula BIGINT--Obligatorio
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM rel_Usuario_Grupo WHERE documento_Usuario=@cedula)
BEGIN
PRINT 'El miembro no existe'
END
ELSE
BEGIN
DELETE FROM rel_Usuario_Grupo WHERE documento_Usuario = @cedula;
END
END
GO
GO
CREATE PROCEDURE prc_ListarMiembros
AS
BEGIN
IF NOT EXISTS(SELECT * FROM rel_Usuario_Grupo)
BEGIN
PRINT 'No existen miembros'
END
ELSE
BEGIN
SELECT nombre_Usuario,nombre_Grupo,alias_Miembro FROM tbl_Grupo
INNER JOIN rel_Usuario_Grupo ON grupo = codigo_Grupo
INNER JOIN tbl_Usuario ON documento_Usuario = cedula_Usuario
END
END
GO
/********************Grupo*********************/
GO
CREATE PROCEDURE prc_GuardarGrupo(
@cod_grupo INT,
@nom_grupo VARCHAR(30),
@fra_grupo VARCHAR(30)
)
AS
BEGIN
IF @cod_grupo = (SELECT codigo_Grupo FROM tbl_Grupo WHERE codigo_Grupo = @cod_grupo)
BEGIN
PRINT 'El grupo ya existe'
END
ELSE
BEGIN
INSERT INTO tbl_Grupo (codigo_Grupo, nombre_Grupo, frase_Grupo) VALUES(@cod_grupo, @nom_grupo, @fra_grupo);
END
END
GO
GO
CREATE PROCEDURE prc_BuscarGrupo(
@cod_grupo INT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Grupo WHERE codigo_Grupo=@cod_grupo)
BEGIN
PRINT 'El grupo no existe'
END
ELSE
BEGIN
SELECT * FROM tbl_Grupo WHERE codigo_Grupo = @cod_grupo;
END
END
GO
GO
CREATE PROCEDURE prc_ModificarGrupo(
@cod_grupo INT,
@nom_grupo VARCHAR(30),
@fra_grupo VARCHAR(30)
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Grupo WHERE codigo_Grupo=@cod_grupo)
BEGIN
PRINT 'El grupo no existe'
END
ELSE
BEGIN
UPDATE tbl_Grupo SET
nombre_Grupo = @nom_grupo,
frase_Grupo = @fra_grupo
WHERE codigo_Grupo = @cod_grupo;
END
END
GO
GO
CREATE PROCEDURE prc_EliminarGrupo(
@cod_grupo INT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Grupo WHERE codigo_Grupo=@cod_grupo)
BEGIN
PRINT 'El grupo no existe'
END
ELSE
BEGIN
DELETE FROM tbl_Grupo WHERE codigo_Grupo = @cod_grupo;
END
END
GO
GO
CREATE PROCEDURE prc_ListarGrupos
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Grupo)
BEGIN
PRINT 'No existen grupos'
END
ELSE
BEGIN
SELECT * FROM tbl_Grupo
END
END
GO
/********************Proyecto*********************/
GO
CREATE PROCEDURE prc_GuardarProyecto(
@cod_proyecto INT,
@nom_proyecto VARCHAR(300),
@desc_proyecto VARCHAR(100)
)
AS
BEGIN
IF @cod_proyecto = (SELECT codigo_Proyecto FROM tbl_Proyecto WHERE codigo_Proyecto = @cod_proyecto)
BEGIN
PRINT 'El proyecto ya existe'
END
ELSE
BEGIN
INSERT INTO tbl_Proyecto (codigo_Proyecto, nombre_Proyecto, descripcion_Proyecto) VALUES(@cod_proyecto, @nom_proyecto, @desc_proyecto);
END
END
GO
GO
CREATE PROCEDURE prc_BuscarProyecto(
@cod_proyecto INT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Proyecto WHERE codigo_Proyecto=@cod_proyecto)
BEGIN
PRINT 'El proyecto no existe'
END
ELSE
BEGIN
SELECT * FROM tbl_Proyecto WHERE codigo_Proyecto = @cod_proyecto;
END
END
GO
GO
CREATE PROCEDURE prc_ModificarProyecto(
@cod_proyecto INT,
@nom_proyecto VARCHAR(300),
@desc_proyecto VARCHAR(100)
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Proyecto WHERE codigo_Proyecto=@cod_proyecto)
BEGIN
PRINT 'El proyecto no existe'
END
ELSE
BEGIN
UPDATE tbl_Proyecto SET
nombre_Proyecto = @nom_proyecto,
descripcion_Proyecto = @desc_proyecto
WHERE codigo_Proyecto = @cod_proyecto;
END
END
GO
GO
CREATE PROCEDURE prc_EliminarProyecto(
@cod_proyecto INT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Proyecto WHERE codigo_Proyecto=@cod_proyecto)
BEGIN
PRINT 'El proyecto no existe'
END
ELSE
BEGIN
DELETE FROM tbl_Proyecto WHERE codigo_Proyecto = @cod_proyecto;
END
END
GO
GO
CREATE PROCEDURE prc_ListarProyectos
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Proyecto)
BEGIN
PRINT 'No existen grupos'
END
ELSE
BEGIN
SELECT * FROM tbl_Proyecto
END
END
GO
/********************Tarea*********************/
GO
CREATE PROCEDURE prc_GuardarTarea(
@cod_tarea INT,
@desc_tarea VARCHAR(100),
@dur_aproximada INT,
@fecha DATE,
@nom_archivo VARCHAR(30)
)
AS
BEGIN
IF @cod_tarea = (SELECT codigo_Tarea FROM tbl_Tarea WHERE codigo_Tarea = @cod_tarea)
BEGIN
PRINT 'La tarea ya existe'
END
ELSE
BEGIN
INSERT INTO tbl_Tarea (codigo_Tarea, descripcion_Tarea, duracion_aproximada, fecha_Entrega, nombre_Archivo)
VALUES(@cod_tarea, @desc_tarea, @dur_aproximada, @fecha, @nom_archivo);
END
END
GO
GO
CREATE PROCEDURE prc_BuscarTarea(
@cod_tarea INT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Tarea WHERE codigo_Tarea=@cod_tarea)
BEGIN
PRINT 'La tarea no existe'
END
ELSE
BEGIN
SELECT * FROM tbl_Tarea WHERE codigo_Tarea = @cod_tarea;
END
END
GO
GO
CREATE PROCEDURE prc_ModificarTarea(
@cod_tarea INT,
@desc_tarea VARCHAR(100),
@dur_aproximada INT,
@fecha DATE,
@nom_archivo VARCHAR(30)
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Tarea WHERE codigo_Tarea=@cod_tarea)
BEGIN
PRINT 'La tarea no existe'
END
ELSE
BEGIN
UPDATE tbl_Tarea SET
descripcion_Tarea = @desc_tarea,
duracion_aproximada = @dur_aproximada,
fecha_Entrega = @fecha,
nombre_Archivo = @nom_archivo
WHERE codigo_Tarea = @cod_Tarea;
END
END
GO
GO
CREATE PROCEDURE prc_EliminarTarea(
@cod_tarea INT
)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Tarea WHERE codigo_Tarea=@cod_tarea)
BEGIN
PRINT 'La tarea no existe'
END
ELSE
BEGIN
DELETE FROM tbl_Tarea WHERE codigo_Tarea = @cod_tarea;
END
END
GO
GO
CREATE PROCEDURE prc_ListarTareas
AS
BEGIN
IF NOT EXISTS(SELECT * FROM tbl_Tarea)
BEGIN
PRINT 'No existen tareas'
END
ELSE
BEGIN
SELECT * FROM tbl_Tarea;
END
END
GO
/***************************Procedures Personalizados*********************************/
GO
CREATE PROCEDURE prc_IniciarSesion(
@us BIGINT,
@cl VARCHAR(40)
)
AS
BEGIN
IF NOT EXISTS(SELECT usuario, clave FROM tbl_Sesion WHERE usuario = @us AND clave = @cl)
BEGIN
PRINT 'No existe el usuario'
END
ELSE
BEGIN
SELECT usuario, clave FROM tbl_Sesion WHERE usuario = @us AND clave = @cl;
END
END
GO
/***************************Procedures Personalizados*********************************/
--
EXECUTE prc_GuardarProfesion 0,'Seleccione profesión','';
EXECUTE prc_GuardarProfesion 1,'Tecnólogo en ADSI','';
EXECUTE prc_GuardarProfesion 2,'Tecnólogo en producción multimedia','';
EXECUTE prc_GuardarRol 0,'Seleccione rol','';
EXECUTE prc_GuardarRol 1,'Diseñador Web','';
EXECUTE prc_GuardarRol 2,'Fotógrafo','';
EXECUTE prc_GuardarRol 3,'Editor','';
EXECUTE prc_GuardarRol 4,'Ilustrador','';
EXECUTE prc_GuardarRol 5,'Analista','';
EXECUTE prc_GuardarRol 6,'Programador','';
EXECUTE prc_GuardarRol 7,'Téster','';

SELECT * FROM tbl_Rol
SELECT * FROM tbl_Profesion
SELECT * FROM rel_Usuario_Rol
SELECT * FROM rel_Usuario_Profesion
SELECT * FROM tbl_Usuario
SELECT * FROM tbl_Tarea

EXECUTE prc_GuardarUsuario 1017264677,'Felipe','Vasquez','a5606@misena.edu.co','3146843200',0,0
EXECUTE prc_ModificarUsuario 1017264677,'Felipe','Gomez','a5606@misena.edu.co','3146843200',2,2


EXECUTE prc_IniciarSesion 1017364677,'algo'

INSERT INTO tbl_Sesion VALUES (15305997,'alejo1998');

