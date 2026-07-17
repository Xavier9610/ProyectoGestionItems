-----------------BASE DE DATOS DE CLIENTE
CREATE DATABASE db_clientes
go
use db_clientes
go
CREATE TABLE tbl_usuario(
	idUsuario	INT IDENTITY(1,1),
	nombreUsuario	VARCHAR(50),
	idCliente	INT----- se asume la relacion con el usuario
)
GO
---- listar usuario
CREATE PROCEDURE sps_usuario 
AS
BEGIN
	select
	idUsuario,
	nombreUsuario,
	idCliente
	from tbl_usuario
END
GO
-------Datos semilla para prueba
INSERT INTO tbl_usuario (nombreUsuario, idCliente) values ('Xavier69',1);
INSERT INTO tbl_usuario (nombreUsuario, idCliente) values ('Xavier70',2);
INSERT INTO tbl_usuario (nombreUsuario, idCliente) values ('Ana4',3);
GO