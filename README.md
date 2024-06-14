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
	completeDate DATETIME,
	mode INT,
	score INT,
	gameTime INT,
	PRIMARY KEY(userId, completeDate),
	FOREIGN KEY(userId) REFERENCES [User](userId)
	);
```

![DB Picture](Bide DB.drawio.png)
