CREATE PROCEDURE [file].[Files_create_disk]
@FileNombre NVARCHAR(100),
@UsuarioID INT
AS
INSERT INTO [file].Files(FileNombre,FileUsuarioRegistro)
	VALUES(@FileNombre, @UsuarioID)
GO