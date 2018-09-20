/*
Скрипт развертывания для TestingBase

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TestingBase"
:setvar DefaultFilePrefix "TestingBase"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.IVANSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.IVANSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Выполняется создание $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Параметры базы данных изменить нельзя. Применить эти параметры может только пользователь SysAdmin.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Параметры базы данных изменить нельзя. Применить эти параметры может только пользователь SysAdmin.';
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Выполняется создание [dbo].[Answers]...';


GO
CREATE TABLE [dbo].[Answers] (
    [AnswerID]          INT           NOT NULL,
    [AnswerDescription] NVARCHAR (50) NULL,
    [AnswerCheck]       INT           NULL,
    [Correct]           INT           NULL,
    [QuestID]           INT           NULL,
    PRIMARY KEY CLUSTERED ([AnswerID] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Questions]...';


GO
CREATE TABLE [dbo].[Questions] (
    [QuestID]          INT           NOT NULL,
    [QuestDescription] NVARCHAR (50) NOT NULL,
    [TestID]           INT           NULL,
    PRIMARY KEY CLUSTERED ([QuestID] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [RoleId]          INT           NOT NULL,
    [RoleDescription] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Tests]...';


GO
CREATE TABLE [dbo].[Tests] (
    [TestID]          INT           NOT NULL,
    [TestDescription] NVARCHAR (50) NOT NULL,
    [TestSubject]     NVARCHAR (50) NULL,
    [TestСomplexity]  INT           NULL,
    PRIMARY KEY CLUSTERED ([TestID] ASC)
);


GO
PRINT N'Выполняется создание [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [UserID]     INT           NOT NULL,
    [UserLogin]  NVARCHAR (50) NOT NULL,
    [UserPassWD] NVARCHAR (50) NOT NULL,
    [UserRole]   INT           NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);


GO
PRINT N'Выполняется создание ограничение без названия для [dbo].[Answers]...';


GO
ALTER TABLE [dbo].[Answers]
    ADD FOREIGN KEY ([QuestID]) REFERENCES [dbo].[Questions] ([QuestID]);


GO
PRINT N'Выполняется создание ограничение без названия для [dbo].[Questions]...';


GO
ALTER TABLE [dbo].[Questions]
    ADD FOREIGN KEY ([TestID]) REFERENCES [dbo].[Tests] ([TestID]);


GO
PRINT N'Выполняется создание ограничение без названия для [dbo].[Users]...';


GO
ALTER TABLE [dbo].[Users]
    ADD FOREIGN KEY ([UserRole]) REFERENCES [dbo].[Roles] ([RoleId]);


GO
insert into Roles(RoleId,RoleDescription) values(1,'admin');
insert into Roles(RoleId,RoleDescription) values(2,'user');

insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(1,'Dunn','TheBest',1);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(2,'Mick','123',2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(3,'Duck','456',2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(4,'Vick','234',2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(5,'Ben','It',2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(6,'Yes','No',2);

insert into Tests(TestID,TestDescription,TestSubject,TestСomplexity) values(1,'What is snow?','nature',1);
insert into Tests(TestID,TestDescription,TestSubject,TestСomplexity) values(2,'We are Human','nature',1);

insert into Questions(QuestID,QuestDescription,TestID) values(1,'What is snow?',1);
insert into Questions(QuestID,QuestDescription,TestID) values(2,'What color is the snow?',1);

insert into Questions(QuestID,QuestDescription,TestID) values(3,'We are Human?',2);
insert into Questions(QuestID,QuestDescription,TestID) values(4,'What color are people?',2);

insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(1,'Yes',1,3);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(2,'No',0,3);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(3,'It water',1,1);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(4,'It dirt',0,1);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(3,'It white',1,1);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(4,'It yellow',0,1);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(3,'It pink',1,4);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(4,'It yellow',0,4);
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Обновление завершено.';


GO
