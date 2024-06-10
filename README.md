# DB
```sql
CREATE TABLE [User](
	userId VARCHAR(20) PRIMARY KEY,
	password VARCHAR(64),
	userName VARCHAR(255));
```

```sql
CREATE TABLE [Game](
	userId VARCHAR(20),
	completeTime DATETIME,
	mode INT,
	score INT,
	gameTime DATETIME,
	PRIMARY KEY(userId, completeTime),
	FOREIGN KEY(userId) REFERENCES [User](userId)
	);
```
