CREATE PROCEDURE [dbo].[Post_getByUserId]
@UsuarioId INT
AS
SELECT * 
FROM Post
WHERE UsuarioId = @UsuarioId 
ORDER BY IDPost desc
