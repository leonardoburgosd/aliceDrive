CREATE PROCEDURE [dbo].[Post_getByUserId]
@UsuarioId INT
AS
SELECT * 
FROM Post
WHERE UsuarioId = @UsuarioId AND Deleted = 0 
ORDER BY IDPost desc
