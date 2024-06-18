CREATE PROCEDURE [GetAllGameInfo_0.3]
AS
BEGIN
	SELECT userName, completeDate, mode, score, gameTime 
	FROM Game, [User]
	ORDER BY score DESC;
END