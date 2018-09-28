insert into Roles(ID,RoleDescription) values(1,'admin');
insert into Roles(ID,RoleDescription) values(2,'user');

insert into Users(ID,UserLogin,UserPassWD,UserRole) values(1,'Dunn','TheBest',1);
insert into Users(ID,UserLogin,UserPassWD,UserRole) values(2,'Mick','123',2);
insert into Users(ID,UserLogin,UserPassWD,UserRole) values(3,'Duck','456',2);
insert into Users(ID,UserLogin,UserPassWD,UserRole) values(4,'Vick','234',2);
insert into Users(ID,UserLogin,UserPassWD,UserRole) values(5,'Ben','It',2);
insert into Users(ID,UserLogin,UserPassWD,UserRole) values(6,'Yes','No',2);
insert into Users(ID,UserLogin,UserPassWD,UserRole) values(7,'admin','admin',1);

insert into Tests(ID,TestDescription,TestSubject,TestСomplexity) values(1,'What is snow?','nature',1);
insert into Tests(ID,TestDescription,TestSubject,TestСomplexity) values(2,'We are Human','nature',1);

insert into Questions(ID,QuestDescription,TestID) values(1,'What is snow?',1);
insert into Questions(ID,QuestDescription,TestID) values(2,'What color is the snow?',1);

insert into Questions(ID,QuestDescription,TestID) values(3,'We are Human?',2);
insert into Questions(ID,QuestDescription,TestID) values(4,'What color are people?',2);

insert into Answers(ID,AnswerDescription,Correct,QuestID) values(1,'Yes',1,3);
insert into Answers(ID,AnswerDescription,Correct,QuestID) values(2,'No',0,3);
insert into Answers(ID,AnswerDescription,Correct,QuestID) values(3,'It water',1,1);
insert into Answers(ID,AnswerDescription,Correct,QuestID) values(4,'It dirt',0,1);
insert into Answers(ID,AnswerDescription,Correct,QuestID) values(5,'It white',1,2);
insert into Answers(ID,AnswerDescription,Correct,QuestID) values(6,'It yellow',0,2);
insert into Answers(ID,AnswerDescription,Correct,QuestID) values(7,'It pink',1,4);
insert into Answers(ID,AnswerDescription,Correct,QuestID) values(8,'It yellow',0,4);