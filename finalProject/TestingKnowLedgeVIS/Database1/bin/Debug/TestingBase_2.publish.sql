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
USE [$(DatabaseName)];


GO
insert into Roles(RoleId,RoleDescription) values(1,"admin");
insert into Roles(RoleId,RoleDescription) values(2,"user");

insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(1,"Dunn","TheBest",1);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(2,"Mick","123",2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(3,"Duck","456",2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(4,"Vick","234",2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(5,"Ben","It",2);
insert into Users(UserID,UserLogin,UserPassWD,UserRole) values(6,"Yes","No",2);

insert into Tests(TestID,TestDescription,TestSubject,TestСomplexity) values(1,"What is snow?","nature",1);
insert into Tests(TestID,TestDescription,TestSubject,TestСomplexity) values(2,"We are Human","nature",1);

insert into Questions(QuestID,QuestDescription,TestID) values(1,"What is snow?",1);
insert into Questions(QuestID,QuestDescription,TestID) values(2,"What color is the snow?",1);

insert into Questions(QuestID,QuestDescription,TestID) values(3,"We are Human?",2);
insert into Questions(QuestID,QuestDescription,TestID) values(4,"What color are people?",2);

insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(1,"Yes",1,3);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(2,"No",0,3);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(3,"It water",1,1);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(4,"It dirt",0,1);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(5,"It white",1,2);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(6,"It yellow",0,2);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(7,"It pink",1,4);
insert into Answers(AnswerID,AnswerDescription,Correct,QuestID) values(8,"It yellow",0,4);
GO

GO
PRINT N'Обновление завершено.';


GO
