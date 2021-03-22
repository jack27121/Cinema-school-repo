--Creates Database
Create Database CinemaDB
use CinemaDB --only one DB connection at a time
go

--Jeg lavede databasen ved hjælp af LucidChart export
CREATE TABLE [Movie] (
  [movieId] int identity (1,1),
  [name] text,
  [ageRating] int default 0,
  [image] text,
  [trailer] text,
  [description] text,
  [release] Date,
  PRIMARY KEY ([movieId])
);

CREATE TABLE [Theater] (
  [theaterId] int identity (1,1),
  [number] text,
  PRIMARY KEY ([theaterId])
);

CREATE TABLE [Show] (
  [showId] int identity (1,1),
  [theaterId] int,
  [movieId] int,
  [date] Date,
  PRIMARY KEY ([showId])
);

CREATE TABLE [MovieGenre] (
  [movieId] int,
  [genre] text
);

CREATE INDEX [PK FK] ON  [MovieGenre] ([movieId]);

CREATE TABLE [Seat] (
  [seatId] int identity (1,1),
  [theaterId] int,
  [row] int,
  [number] int,
  PRIMARY KEY ([seatId])
);

CREATE TABLE [User] (
  [userId] int identity (1,1),
  [firstName] varchar(100),
  [lastName] varchar(100),
  [phone] int,
  [admin] bit,
  PRIMARY KEY ([userId])
);

CREATE TABLE [Ticket] (
  [TicketId] int identity (1,1),
  [seatId] int,
  [showId] int,
  [qrCode] text,
  PRIMARY KEY ([TicketId])
);

CREATE TABLE [Genre] (
  [genreId] int identity (1,1),
  [genreName] varchar(100),
  PRIMARY KEY ([genreId])
);