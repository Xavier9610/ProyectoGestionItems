--------------base de datos de items (tareas)
CREATE DATABASE db_item_trabajo
GO
use db_item_trabajo
go
CREATE TABLE tbl_item(
	idItem				INT IDENTITY(1,1),
	nombre				VARCHAR(100),
	descripcion			VARCHAR(100),
	fechaEntrega		DATETIME,
	relevancia			BIT
)
GO
insert into tbl_item values ('Cocinar','Cuando se cocina','2026-07-18',0);
insert into tbl_item values ('Lavar','Cuando se lava','2026-07-29',0);
insert into tbl_item values ('Comer','Cuando se come','2026-07-25',1);
insert into tbl_item values ('Dormir','Cuando se duerme','2026-07-25',1);
GO
CREATE TABLE tbl_item_usuario(
	idItemUsuario		INT IDENTITY(1,1),
	idItem				INT,
	idUsuario			INT,
	completado			BIT,
	fechaEntrega		DATETIME,
	relevancia			bit
)
GO
----- inserta un item
CREATE PROCEDURE spi_item (
@nombre VARCHAR(100),
@descripcion VARCHAR(100),
@fechaEntrega VARCHAR(100),
@relevncia BIT
)
AS
BEGIN
	insert into tbl_item (nombre, descripcion, fechaEntrega, relevancia) 
	values (@nombre, @descripcion, @fechaEntrega, @relevncia)
END
GO
----- lista items
CREATE PROCEDURE sps_item 
AS
BEGIN
	select
		idItem, nombre, descripcion, fechaEntrega, relevancia
	from tbl_item
END
GO
---- asignar item
CREATE PROCEDURE spi_item_usuario (
@idItem int,
@idUsuario int,
@estadoTarea bit,
@fechaEntrega datetime,
@relevancia bit
)
AS
BEGIN
	insert into tbl_item_usuario(idItem, idUsuario, completado, fechaEntrega, relevancia) 
	values (@idItem, @idUsuario, @estadoTarea, @fechaEntrega, @relevancia)
END
GO
---- listar item por usuario
CREATE PROCEDURE sps_item_usuario (
@idUsuario int
)
AS
BEGIN
	select
	idItem,
	idItemUsuario,
	idUsuario,
	completado,
	fechaEntrega,
	relevancia
	from tbl_item_usuario
	where idUsuario = @idUsuario
END
GO
---- listar item usuario general
CREATE PROCEDURE sps_item_usuario_todo
AS
BEGIN
	select
	idItem,
	idItemUsuario,
	idUsuario,
	completado,
	fechaEntrega,
	relevancia
	from tbl_item_usuario
END
GO

delete from tbl_item_usuario

select * from tbl_item
select * from tbl_item_usuario