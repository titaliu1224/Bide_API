CREATE PROCEDURE [InsertGameResult_0.1]
@userId VARCHAR(20),
@completeDate DATETIME,
@mode INT,
@score INT,
@gameTime INT
AS
BEGIN
	INSERT INTO Game(userId, completeDate, mode, score, gameTime)
	VALUES(@userId, @completeDate, @mode, @score, @gameTime)
END;