CREATE PROCEDURE [file].[Files_select_disk]
@UsuarioID INT
AS
SELECT FileBase,FileNombre,FileFechaRegistro,FileType
FROM [file].Files
WHERE FileEliminado = 0 AND FilePadreID = 0 AND FileUsuarioRegistro = @UsuarioID
GO