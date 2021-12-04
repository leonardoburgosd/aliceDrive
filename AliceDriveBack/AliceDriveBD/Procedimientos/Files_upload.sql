CREATE PROCEDURE [file].[Files_upload]
@FileNombre VARCHAR(100),
@FileSize INT,
@FileType NVARCHAR(40),
@FileBase NVARCHAR(255),
@FileUsuarioRegistro INT
AS
INSERT INTO [file].[Files](
				[FileNombre],
				[FileSize],
				[FileType],
				[FilePadreID],
				[FileUsuarioRegistro]
			)
		VALUES(
				@FileNombre,
				@FileSize,
				@FileType,
			   (SELECT [FilesId] FROM [file].[Files] WHERE [FileBase] = @FileBase AND [FileEliminado]=0),
			   @FileUsuarioRegistro
			)