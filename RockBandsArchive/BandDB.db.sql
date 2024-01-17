BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
CREATE TABLE IF NOT EXISTS "Genres" (
	"GenreId"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_Genres" PRIMARY KEY("GenreId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Bands" (
	"BandId"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL,
	"Origen"	TEXT NOT NULL,
	"GenreId"	INTEGER NOT NULL,
	CONSTRAINT "PK_Bands" PRIMARY KEY("BandId" AUTOINCREMENT),
	CONSTRAINT "FK_Bands_Genres_GenreId" FOREIGN KEY("GenreId") REFERENCES "Genres"("GenreId") ON DELETE CASCADE
);
INSERT INTO "__EFMigrationsHistory" VALUES ('20230914101616_initilCreate','7.0.11');
INSERT INTO "Genres" VALUES (1,'Progressive Metal');
INSERT INTO "Genres" VALUES (2,'Power Metal');
INSERT INTO "Genres" VALUES (3,'Acid Jazz');
INSERT INTO "Genres" VALUES (4,'Fusion Jazz');
INSERT INTO "Genres" VALUES (5,'Rock');
INSERT INTO "Bands" VALUES (1,'Andy James','UK',1);
INSERT INTO "Bands" VALUES (2,'Dream Theater','USA',1);
INSERT INTO "Bands" VALUES (3,'Animals as Leaders','USA',3);
INSERT INTO "Bands" VALUES (4,'Haken','UK',1);
INSERT INTO "Bands" VALUES (5,'Adagio','FRE',2);
INSERT INTO "Bands" VALUES (6,'Guthrie Govan','Uk',3);
CREATE INDEX IF NOT EXISTS "IX_Bands_GenreId" ON "Bands" (
	"GenreId"
);
COMMIT;
