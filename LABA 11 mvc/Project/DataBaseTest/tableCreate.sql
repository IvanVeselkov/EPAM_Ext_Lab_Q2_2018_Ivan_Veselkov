create table Roles(
RoleId int primary key,
RoleDescription nvarchar(50) not null
);
go
create table Users(
UserID int primary key,
UserLogin nvarchar(50) not null,
UserPassWD nvarchar(50) not null,
UserRole int FOREIGN KEY REFERENCES Roles(RoleID)
);
go
create table Tests(
TestID int primary key,
TestDescription nvarchar(50) not null,
TestSubject nvarchar(50),
TestСomplexity int
);
go
create table Questions(
QuestID int primary key,
QuestDescription nvarchar(50) not null,
TestID int foreign key references Tests(TestID)
);
go
create table Answers(
AnswerID int primary key,
AnswerDescription nvarchar(50),
AnswerCheck int,
Correct int,--0 incorrect 1 correct answert
QuestID int foreign key references Questions(QuestID)
);
go