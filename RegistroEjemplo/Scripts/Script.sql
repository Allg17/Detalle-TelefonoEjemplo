CREATE DATABASE RegistroPersonaEjemplo
GO
USE RegistroPersonaEjemplo
GO
CREATE TABLE Personas
(
	IdPersona int primary key identity(1,1),
	Nombre varchar(30),
	Telefono varchar(13),
	Cedula varchar(13),
	Direccion varchar(max)
);
go

CREATE TABLE  TelefonoDetalles
(
	Id int primary key identity(1,1),
	IdPersona int,
	TipoTelefono varchar(15),
	Telefono varchar(15)
);