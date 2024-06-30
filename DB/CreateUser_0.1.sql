CREATE PROCEDURE [CreateUser_0.1]
	@userId VARCHAR(20),
	@password VARCHAR(64),
	@userName VARCHAR(255)
AS
BEGIN
	INSERT INTO [User](userId, [password], userName)
	VALUES(@userId, @password, @userName);
END