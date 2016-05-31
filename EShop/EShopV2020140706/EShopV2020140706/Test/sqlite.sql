CREATE TABLE Users(
   UserName TEXT PRIMARY KEY,
   Password TEXT,
   FullName TEXT NOT NULL,
   Email TEXT NOT NULL,
   PhoneNumber TEXT NOT NULL
);
CREATE TABLE Items(
   Id INTEGER PRIMARY KEY,
   Name TEXT NOT NULL,
   Image TEXT
);
CREATE TABLE Transactions(
   Id INTEGER PRIMARY KEY,
   ItemId INTEGER NOT NULL,
   Money REAL NOT NULL,
   Source TEXT,
   UserId INTEGER NOT NULL,
   Date INTEGER NOT NULL,
   Notes TEXT NOT NULL,
   FOREIGN KEY (ItemId) REFERENCES Items(Id),
   FOREIGN KEY (UserId) REFERENCES Users(Id)
);