CREATE PROCEDURE [dbo].[Post_create]
@DetallePost NVARCHAR(MAX),
@UsuarioId INT
AS
INSERT INTO Post(
				DetallePost,
				UsuarioId
				)
		VALUES(
				@DetallePost,
				@UsuarioId
			  )