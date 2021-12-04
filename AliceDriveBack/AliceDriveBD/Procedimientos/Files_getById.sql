CREATE PROCEDURE [file].[Files_getById]
@UsuarioId INT,
@FileId INT
AS
select FilePadreID,FileNombre 
from [file].[Files]
where FilesId = @FileId 
AND FileUsuarioRegistro = @UsuarioId

