CREATE TABLE [file].[Files]
(
	FilesId INT IDENTITY PRIMARY KEY,
	FileBase NVARCHAR(255) DEFAULT NEWID() NOT NULL,
	FileNombre NVARCHAR(100) NOT NULL,
	FileSize INT DEFAULT 0 NOT NULL,
	FileType NVARCHAR(40) DEFAULT 'disc',
	FilePadreID INT DEFAULT 0 NOT NULL,
	FileUsuarioRegistro INT NOT NULL,
	FileFechaRegistro DATETIME DEFAULT GETUTCDATE(),
	FileUsuarioModificado INT,
	FileFechaModificado DATETIME,
	FileEliminado BIT DEFAULT 0
)
