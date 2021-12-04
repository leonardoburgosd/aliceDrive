CREATE PROCEDURE [file].[Files_select_childs]
@UsuarioId INT,
@FileBase NVARCHAR(255)
AS
SELECT FileBase, FileNombre, FileSize, FileType
FROM [file].Files
WHERE FilePadreID = (
		SELECT FilesId
		FROM [file].Files
		WHERE FileBase = @FileBase
	)
AND FileEliminado = 0 AND FileUsuarioRegistro = 1