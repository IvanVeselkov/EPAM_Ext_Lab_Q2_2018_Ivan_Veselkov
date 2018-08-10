create table Roles(
RoleId int primary key,
RoleDescription nvarchar(50) not null
)
go
create table Users(
UserID int primary key,
UserLogin nvarchar(50) not null,
UserPassWD nvarchar(50) not null,
UserRole int FOREIGN KEY REFERENCES Roles(RoleID)
)
go
create table Tests(
TestID int primary key,
TestDescription nvarchar(50) not null,
TestSubject nvarchar(50),
TestСomplexity int
)
go

--дополниельные сущности будут создаваться при добавлении новых тестов