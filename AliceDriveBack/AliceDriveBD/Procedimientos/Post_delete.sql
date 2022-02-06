CREATE PROCEDURE [dbo].[Post_delete]
@IdPost INT
AS
update Post 
set Deleted = 1
where IDPost = @IdPost
