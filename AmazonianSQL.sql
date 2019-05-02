EXEC sp_configure filestream_access_level, 2
RECONFIGURE

--------------------------------------------------------

CREATE DATABASE DB_A47346_AmazonianWillow

--------------------------------------------------------

ALTER DATABASE DB_A47346_AmazonianWillow
ADD FILEGROUP FILESTREAM_Data CONTAINS FILESTREAM 
GO

--------------------------------------------------------

ALTER DATABASE DB_A47346_AmazonianWillow
ADD FILE
(
NAME = 'FILESTREAM_Data',
FILENAME = 'H:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\FILESTREAM_Data'
)
TO FILEGROUP FILESTREAM_Data
GO

--------------------------------------------------------

USE DB_A47346_AmazonianWillow

--------------------------------------------------------
CREATE TABLE Estado(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion VARCHAR(MAX) NOT NULL,
);

CREATE TABLE Imagen
(
	id_Imagen INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	id_Imagen_FileStream UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL UNIQUE DEFAULT NEWID(),
	imagen VARBINARY(MAX) FILESTREAM NOT NULL
);

CREATE TABLE Tipo_Habitacion(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	titulo VARCHAR(100) NOT NULL,
	tarifa float NOT NULL,
	descripcion VARCHAR(MAX) NOT NULL,
	imagen INT NOT NULL FOREIGN KEY REFERENCES Imagen(id_Imagen)
);

CREATE TABLE Habitacion(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	numero INT NOT NULL,
	estado INT NOT NULL FOREIGN KEY REFERENCES Estado(id),
	tipo INT NOT NULL FOREIGN KEY REFERENCES Tipo_Habitacion(id)
);

CREATE TABLE Caracteristica(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion VARCHAR(MAX) NOT NULL,
	tipo INT NOT NULL FOREIGN KEY REFERENCES Tipo_Habitacion(id)
);

CREATE TABLE Reservacion(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	identificacion varchar(25),
	nombre VARCHAR(100) NOT NULL,
	apellidos VARCHAR(100) NOT NULL,
	correo VARCHAR(256) NOT NULL,
	tarjeta VARCHAR(256) NOT NULL,
	fechaInicio DATE NOT NULL,
	fechaFin DATE NOT NULL,
	--monto FLOAT NOT NULL,
	habitacion INT NOT NULL FOREIGN KEY REFERENCES Habitacion (id),
	estado INT NOT NULL FOREIGN KEY REFERENCES Estado(id)
);

CREATE TABLE Publicidad(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	url VARCHAR(1000) NOT NULL,
	imagen INT NOT NULL FOREIGN KEY REFERENCES Imagen(id_Imagen),
	estado INT NOT NULL FOREIGN KEY REFERENCES Estado(id)
);

CREATE TABLE Promocion(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion varchar (100) Not Null,
	descuento FLOAT,
	inicio DATE,
	fin DATE,
	imagen INT NOT NULL FOREIGN KEY REFERENCES Imagen(id_Imagen)
);

CREATE TABLE Pagina(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Info(
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion VARCHAR(MAX),
	titulo VARCHAR(MAX),
	idPagina INT NOT NULL FOREIGN KEY REFERENCES Pagina (id),
	imagen INT FOREIGN KEY REFERENCES Imagen(id_Imagen)
);


CREATE TABLE Administrador(
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	correo VARCHAR(100) NOT NULL UNIQUE,
	contrasenna VARCHAR(100) NOT NULL
);

--------------------------------------------------------
CREATE PROCEDURE sp_checkAvailability @idTipoHabitacion INT, @fechaInicio Date, @fechaFin Date
AS BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	Declare @numero int, @titulo varchar(100), @descripcion varchar(max), @tarifa float
		If exists(SELECT Habitacion.Numero FROM Habitacion WHERE Habitacion.Id_Tipo_Habitacion = @idTipoHabitacion AND Habitacion.Id_Estado = 1)
		BEGIN
			SELECT TOP 1 @numero = Habitacion.Numero, @titulo = Tipo_Habitacion.Titulo, @descripcion = Tipo_Habitacion.Descripcion, @tarifa = Tipo_Habitacion.Tarifa
			FROM Habitacion, Tipo_Habitacion
			WHERE Habitacion.Id_Tipo_Habitacion = Tipo_Habitacion.Id_Tipo_Habitacion AND Tipo_Habitacion.Id_Tipo_Habitacion = @idTipoHabitacion AND Habitacion.Id_Estado = 1;

			Update Habitacion Set Habitacion.Id_Estado = 10 Where Habitacion.Numero = @numero;

			SELECT @numero as numero, @titulo as titulo, @descripcion as descripcion, @tarifa as tarifa;
		END
		Else
		Begin
			Select 'No hay Habitaciones' as respuesta;
		End
	COMMIT TRANSACTION;
	RETURN (1);
	END TRY  
	BEGIN CATCH  
		ROLLBACK		
		SELECT   
        ERROR_NUMBER() AS ErrorNumber, ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState, ERROR_PROCEDURE() AS ErrorProcedure,  
        ERROR_LINE() AS ErrorLine, ERROR_MESSAGE() AS ErrorMessage;  
		RETURN(-1)
	END CATCH;  		
END
GO
