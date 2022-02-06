CREATE PROCEDURE [dbo].[Post_create]
@DetallePost NVARCHAR(MAX),
@UsuarioId INT,
@Tipo NVARCHAR(100)
AS
INSERT INTO Post(
				DetallePost,
				UsuarioId,
				Tipo
				)
		VALUES(
				@DetallePost,
				@UsuarioId,
				@Tipo
			  )