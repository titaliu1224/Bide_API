CREATE TABLE [Game](
	userId VARCHAR(20),
	completeTime DATETIME,
	mode INT,
	score INT,
	gameTime DATETIME,
	PRIMARY KEY(userId, completeTime),
	FOREIGN KEY(userId) REFERENCES [User](userId)
);