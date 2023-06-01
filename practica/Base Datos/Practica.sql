
USE  Practica;

create table Persona(
Id varchar (50),
Nombre varchar(50),
Apellido1 varchar (50),
Apellido2 varchar (50),
FechaNacimiento Datetime,
Genero varchar(50),
Direccion varchar (80),
Telefono int,
CorreoElectronico varchar (60),
Nacionalidad varchar(60),
CONSTRAINT PK_Persona PRIMARY KEY (id));


-----Insertar

CREATE PROCEDURE P_Insertar
@Id varchar(50),
@Nombre varchar(50),
@Apellido1 varchar(50),
@Apellido2 varchar(50),
@FechaNacimiento Datetime,
@Genero varchar(50),
@Direccion varchar(80),
@Telefono int,
@CorreoElectronico varchar(60),
@Nacionalidad varchar(60)
AS
BEGIN
	INSERT INTO dbo.Persona(
		Id, Nombre, Apellido1, Apellido2, FechaNacimiento, Genero,Direccion,Telefono,CorreoElectronico,Nacionalidad)
		VALUES(@Id, @Nombre, @Apellido1, @Apellido2, @FechaNacimiento, @Genero,@Direccion,@Telefono,@CorreoElectronico,@Nacionalidad)
END
GO


----Selec por id

CREATE PROCEDURE [dbo].[P_SelectporId]
@Id varchar(50)
AS
BEGIN
	SELECT * FROM dbo.Persona WHERE Id=@Id
END
GO


----Actualizar

CREATE PROCEDURE P_Actualizar
@Id varchar(50),
@Nombre varchar(50),
@Apellido1 varchar(50),
@Apellido2 varchar(50),
@FechaNacimiento Datetime,
@Genero varchar(50),
@Direccion varchar(80),
@Telefono int,
@CorreoElectronico varchar(60),
@Nacionalidad varchar(60)
AS
BEGIN
	Update dbo.Persona
		set Nombre=@Nombre, Apellido1= @Apellido1, Apellido2=@Apellido2, 
		FechaNacimiento=@FechaNacimiento, Genero=@Genero,Direccion=@Direccion,Telefono=@Telefono,
		CorreoElectronico=@CorreoElectronico,Nacionalidad=@Nacionalidad WHERE Id=@Id

		
END
GO


----Eliminar

CREATE PROCEDURE P_Eliminar
@Id varchar(50)

AS
BEGIN
	Delete dbo.Persona WHERE Id=@Id
END
GO




----Select all



CREATE PROCEDURE [dbo].[P_Select]
AS
BEGIN
	SELECT * FROM dbo.Persona
END
GO



