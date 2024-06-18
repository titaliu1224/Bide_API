CREATE PROCEDURE [GetAllGameInfo_0.2]
AS
BEGIN
	SELECT userName, completeDate, mode, score, gameTime 
	FROM Game, [User]
END