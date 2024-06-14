CREATE TABLE [Game](
    userId VARCHAR(20),
    completeDate DATETIME,
    mode INT,
    score INT,
    gameTime INT,
    PRIMARY KEY(userId, completeDate),
    FOREIGN KEY(userId) REFERENCES [User](userId)
);