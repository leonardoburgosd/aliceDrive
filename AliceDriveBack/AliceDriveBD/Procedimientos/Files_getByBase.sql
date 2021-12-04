CREATE PROCEDURE [file].[Files_getByBase]
@UsuarioId INT,
@FileBase NVARCHAR(255)
AS
SELECT FilePadreID,FileNombre,FileType
FROM [file].Files
WHERE FileBase = @FileBase AND FileUsuarioRegistro = @UsuarioId