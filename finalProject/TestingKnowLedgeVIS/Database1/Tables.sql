create table Roles(
ID int primary key,
RoleDescription nvarchar(50) not null
);
go
create table Users(
ID int primary key,
UserLogin nvarchar(50) not null,
UserPassWD nvarchar(50) not null,
UserRole int FOREIGN KEY REFERENCES Roles(ID)
);
go
create table Tests(
ID int primary key,
TestDescription nvarchar(50) not null,
TestSubject nvarchar(50),
TestСomplexity int
);
go
create table Questions(
ID int primary key,
QuestDescription nvarchar(50) not null,
TestID int foreign key references Tests(ID)
);
go
create table Answers(
ID int primary key,
AnswerDescription nvarchar(50),
AnswerCheck int,
Correct int,--0 incorrect 1 correct answert
QuestID int foreign key references Questions(ID)
);
go