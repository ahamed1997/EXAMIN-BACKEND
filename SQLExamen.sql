create database dbExamen
---WORKING CODES---
select * from tblCandidates
truncate table tblCandidates

alter table tblCandidates
drop column degree
alter table tblCandidates
add name varchar(100)

select * from tblCandidates
 table tblCandidates
delete from tblCandidates where username in  (select username from tblCandidates)

---- creating store proc for inserting the  data---
alter table tblCandidates values(degree varchar(50),
phone varchar(20) ,email varchar(100),username varchar(50) primary key,password varchar(50),yop varchar(20),name varchar(100))


alter proc proc_RegisterCandidates(@p_phone varchar(20),@p_email varchar(100),@p_username varchar(50),@p_password varchar(50),@p_name varchar(100))
as
begin
insert into tblCandidates values(@p_phone,
@p_email,@p_username,@p_password,@p_name)
end

exec proc_RegisterCandidates'B.Esc','72722882','ahmdgd@shsgs.com','ur','535','2019','ahamed'

--GET ALL USERS--

alter proc proc_GetAllUsers
as
begin
select password,username from tblCandidates
end
exec proc_GetAllUsers
--VALIDATION--

create proc proc_UserValidation(@p_Username varchar(50), @p_password varchar(50))
as
begin
select * from tblCandidates where username = @p_Username AND password = @p_password
end

exec proc_UserValidation '627272@','gssg535'

--PAYMENT--

create table tblPayment(CandidateId varchar(20) primary key, Username varchar(50) foreign key references tblCandidates(username),
TestModel varchar(50),Payment varchar(10))

create proc proc_Payment(@p_CandidateId varchar(20), @p_Username varchar(50),@p_TestModel varchar(50),@p_Payment varchar(10))
as
begin
insert into tblPayment values(@p_CandidateId,@p_Username,@p_TestModel,@p_Payment)
end

select * from tblPayment

drop table tblQuestions
exec proc_Payment '2356','627272@','Aptitude','yes'
--Questions TABLE --

create table tblQuestions(SNo int constraint pk_Sn primary key,TestModel varchar(50),Questions varchar(1000),
Answers varchar(100),option1 varchar(100),option2 varchar(200),option3 varchar(300),option4 varchar(400),
Mark int)

select * from tblQuestions
truncate table tblQuestions
Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(01,'Aptitude',
'A sum of money at simple interest amounts to Rs. 815 in 3 years and to Rs. 854 in 4 years','Rs.698','Rs.650','Rs.690','Rs.698','Rs.700',1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(02,'Aptitude',
'A sum fetched a total simple interest of Rs. 4016.25 at the rate of 9 p.c.p.a. in 5 years. What is the sum?','Rs.8925',
'Rs.4462.50',
'Rs.8032.50',
'Rs.8900',
'Rs.8925',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(03,'Aptitude',
'The percentage increase in the area of a rectangle, if each of its sides is increased by 20% is:',
'44%',
'42%',
'43%',
'44%',
'45%',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(04,'Aptitude',
'Three unbiased coins are tossed. What is the probability of getting at most two heads?','7/8',
'2/5',
'5/6',
'3/4',
'7/8',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(05,'Aptitude',
'What is the probability of getting a sum 9 from two throws of a dice?','1/9',
'12/14',
'2/3',
'1/9',
'1/7',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(06,'Aptitude',
'Which one of the following is not a prime number?','91',
'61',
'51',
'31',
'91',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(07,'Aptitude',
'What least number must be added to 1056, so that the sum is completely divisible by 23 ?','2',
'2',
'18',
'21',
'3',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(08,'Aptitude',
'In a 100 m race, A can give B 10 m and C 28 m. In the same race B can give C','20m',
'18m',
'20m',
'27m',
'9m',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(09,'Aptitude',
'In a 100 m race, A beats B by 10 m and C by 13 m. In a race of 180 m, B will beat C by','6m',
'5.4m',
'4.5m',
'5m',
'6m',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(10,'Aptitude',
'If log 2 = 0.3010 and log 3 = 0.4771, the value of log5 512 is','3.786',
'2.870',
'2.967',
'3.786',
'3.912',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(11,'Technical',
'Which of this method of class String is used to obtain a length of String object?','length()',
'get()',
'lengthof()',
'length()',
'sizeof()',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(12,'Technical',
' Which of these class is superclass of String and StringBuffer class?','java.lang',
'java.lang',
'java.util',
'ArrayList',
'none',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(13,'Technical',
'What is it called if an object has its own lifecycle and there is no owner?','Association',
'Aggregation',
'Encapsulation',
'Composition',
'Association',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(14,'Technical',
'When does method overloading is determined?','At compile time',
'At run time',
'At compile time',
'At execution time',
'At coding time',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(15,'Technical',
'Which of the following is a type of polymorphism in Java?','Compile time polymorphism',
'Compile time polymorphism',
'Execution time polymorphism',
'Multiple polymorphism',
'Multilevel polymorphism',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(16,'Technical',
'Which of the following is not OOPS concept in Java?','compilation',
'Inheritance',
'Abstraction',
'Polymorphism',
'compilation',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(17,'Technical',
'Which of the following is a method having same name as that of its class?','constructor',
'finalize',
'delete',
'constructor',
'class',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(18,'Technical',
'Which of these constructors is used to create an empty String object?','String()',
'String()',
'String(void)',
'String(0)',
'none',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(19,'Technical',
'What is the return type of Constructors?','none of the mentioned above',
'int',
'float',
'void',
'none of the mentioned above',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(20,'Technical',
'Which one of these lists contains only Java programming language keywords?','goto, instanceof, native, finally, default, throws',
'class, if, void, long, Int, continue',
'goto, instanceof, native, finally, default, throws',
'try, virtual, throw, final, volatile, transient',
'strictfp, constant, super, implements, do',1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(21,'Aptitude',
'If successive discounts are 10%, 20% and 30%, then what is its single equivalent discount?',
'49.6%',
'60%',
'40.56%',
'49.6%',
'30%',
1)

--delete from tblQuestions where SNo=21

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(22,'Aptitude',
'A train 360 m long is running at a speed of 45 km/hr. In what time will it pass a bridge 140 m long?',
'40 sec',
'40 sec',
'42 sec',
'45 sec',
'48 sec',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(23,'Aptitude',
'39 persons can repair a road in 12 days, working 5 hours a day. In how many days will 30 persons, working 6 hours a day, complete the work?',
'13',
'10',
'13',
'14',
'15',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(24,'Aptitude',
'By investing in 16% stock at 64, one earns Rs. 1500. The investment made is:',
'rs. 5760',
'Rs. 5640',
'Rs. 5760',
'Rs. 7500',
'Rs. 9600',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(25,'Aptitude',
'A 6% stock yields 8%. The market value of the stock is:',
'Rs.75',
'Rs. 48',
'Rs. 75',
'Rs. 96',
'Rs. 133.33',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(26,'Aptitude',
'The angle between the minute hand and the hour hand of a clock when the time is 8.30, is:',
'75°',
'80°',
'60°',
'75°',
'105°',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(27,'Aptitude',
'10 women can complete a work in 7 days and 10 children take 14 days to complete the work. How many days will 5 women and 10 children take to complete the work?',

'7',
'7',
'5',
'3',
'Cannot be determined',

1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(28,'Aptitude',
'Q is as much younger than R as he is older than T. If the sum of the ages of R and T is 50 years, what is definitely the difference between R and Q age?',
'Data inadequate',
'1 year',
'2 years',
'25 years',
'Data inadequate',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(29,'Aptitude',	
'The population of a town increased from 1,75,000 to 2,62,500 in a decade. The average percent increase of population per year is:',
'5%',
'4.37%',
'5%',
'6%',
'8.75%',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(30,'Aptitude',	
'In how many ways can a group of 5 men and 2 women be made out of a total of 7 men and 3 women?',
'63',
'63',
'90',
'126',
'45',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(31,'Technical',
'Observables help you to manage',
'Asynchronous data',
'Synchronous data',
'Asynchronous data',
'Both asynchronous & synchronous data',
'None of above',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(32,'Technical',
 'RxJS can be used for in Angular?',
 'Both',
 'Browser',
 'Server Side',
' Both',
'None of above',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(33,'Technical',
'Where are the local variable stored ?',
'In a Queue',
'In a Queue',
'In stack Memory',
'In hard Disk',
'In heap Memory',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(34,'Technical',
'while declaring parameters for main, the second parameter argv should be declared as',
'char * argv[]',
'char argv[]',
'char argv',
'char ** argv[]',
'char * argv[]',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(35,'Technical',
'which of the below function is NOT declared in math.h ?',
'and()',
'and()',
'pow()',
'exp()',
'acos()',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(36,'Technical',
' Which of this is used to skip one iteration:',
'continue',
'break',
'continue',
'goto',
'return',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(37,'Technical',
'Automatic variables are stored in',
'stack',
'stack',
'data segment',
'register',
'heap',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(38,'Technical',
'Register variables reside in',
'registers',
'stack',
'registers',
'heap',
'main memory',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(39,'Technical',
'What is the size of an int data type?',
'Depends on the system/compiler',
'4 Bytes',
'8 Bytes',
'Depends on the system/compiler',
'Cannot be determined',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(40,'Technical',
'What type of value does sizeof return?',
'unsigned int',
'char',
'short',
'unsigned int',
'long',
1)

-------------------------------------------------------------------------------
--------------------------------------PROC FOR QUESTIONS BY SERIAL NUMBER
create proc proc_SelectQuestionsBySno(@sno int)
as begin
select * from tblquestions where SNo=@sno
end

exec proc_SelectQuestionsBySno 40
------------------------------------------------PROC FOR getting RANDOM questions using testmodel
select * from tblQuestions

alter proc proc_GetAllQuestions(@TestModel varchar(50))
as
begin
  select top 10 SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark from tblQuestions where TestModel=@TestModel order by NEWID()  
  end
  

exec proc_GetAllQuestions 'Aptitude'
-----------------------------------------------------------------------------------------------
---------------------------------------------------------------PROC FOR INSERTING ANSWER AND FLAG WITH SNO
 create table tblTempScoreFlag(SNo int,userflag int,score int,Testid varchar(20))

 drop table tblTempScoreFlag
 alter proc proc_InsertScoreandFlag(@sno int,  @userflag int,@score int,@testid varchar(20))
 as
 begin 
 IF EXISTS (SELECT * FROM tblTempScoreFlag WHERE SNo=@sno AND Testid = @testid)
    UPDATE tblTempScoreFlag SET  userflag = @userflag , score = @score,Testid=@testid WHERE SNo=@sno
ELSE
    INSERT INTO tblTempScoreFlag VALUES (@sno,@userflag,@score,@testid)
	select count(*) from tblTempScoreFlag WHERE Testid=@testid AND score=1
end


exec proc_InsertScoreandFlag  10,0,0,'59314'

 select * from tblTempScoreFlag

 truncate table tblTempScoreFlag
 select count(*) from tblTempScoreFlag where score=1
 -----------------------------------------------------------------------------------------------------------------------

 

 ----------------------------------------------GET CANDIDATE SCORES ------------------------------------
 select * from [dbo].[User]
 delete from [dbo].[User] where UserName ='kjwenfiei'



 select * from tblCandidates
delete  tblCandidates
 delete from tblCandidates where username='ur'

 
 sp_help tblCandidates
 create proc proc_InsertIntotblCandidates(@phone varchar(20),@email varchar(100),@username varchar(50),@password varchar(50),@name varchar(100))
 as
 begin
 insert into tblCandidates values(@phone,@email,@username,@password,@name)
 end
 ----
 exec proc_InsertIntotblCandidates 'wefwe','ewrferfwer','eererer','efwer','rfewrfer'
 ---------------------------------------------------------------------------------------------------------------------
 -------------------------forgot password using aythguard---------------------------
 select * from tblCandidates
 create proc proc_ForgotPassword(@mail varchar(100))
 as
 begin
 select password from tblCandidates where email = @mail
 end

 exec proc_ForgotPassword 'aravind@gmail.com'
 ----------------------------------------------------------------------------------------------------------------------

alter proc proc_GetCandidateScore(@testid varchar(20))
 as
 begin
 
	select count(*) from tblTempScoreFlag where score =1 AND Testid=@testid

end
 exec proc_GetCandidateScore

select * from tblTempScoreFlag

alter proc proc_Truncate(@testid varchar(20))
as
begin
 delete from tblTempScoreFlag where Testid = @testid
 end


exec proc_Truncate
------------------------------------------------------------------------------------------------------------------------
-------------------------------------PROC FOR SELECTING FLAG WITH SNO-----------------------------------------------------
alter proc proc_SelectFlag(@sno int,@testid varchar(20))
as
begin
select userflag from tblTempScoreFlag  where SNo = @sno AND Testid=@testid
end

exec proc_SelectFlag 2, '58314'


----------------------------------------------------------------------------------------------------------------------------
----SCORE TABLE-----------------------------------------------------------------------------
select * from tblTempScores

insert into tblTempScores values (123,2)
alter proc proc_dummy (@id varchar(20))
as
begin
select * from tblTempScores where candidateid=@id
end

sp_help tblTempScores
exec proc_dummy '123'
----------------------------------------------------------------------------------------------------------------------------------------------------------------

------------------------------------TABLE FPR PAYMENT AND ITS PROCESS----------
sp_help tblCandidates
select * from tblCandidates
drop table tblPayment
create table tblPayment(username varchar(50),testid varchar(20),testmodel varchar(50),testdate varchar(20),paymentmode varchar(50),teststatus varchar(50),result int,payeddate varchar(20),cancelleddate varchar(20))

alter proc proc_InsertIntoPaymentTable(@username varchar(50),@testid varchar(20),@testmodel varchar(20),@testdate varchar(20),@paymentmode varchar(50),@teststatus varchar(50),@result int,@payeddate varchar(20),@cancelleddate varchar(20))
as
begin
insert into tblPayment values(@username,@testid,@testmodel,@testdate,@paymentmode,@teststatus,@result,@payeddate,@cancelleddate);
end
select * from tblPayment
delete from tblPayment

update tblPayment set testdate=testdate + 01 where testid='8006'
insert into tblPayment values ('hulk','861','Technical','2019-12-20','Debit','Upcoming',0)
exec proc_InsertIntoPaymentTable 'hulk','861','Technical','2019-12-20','Debit','Upcoming',0
---get user payed data by user name--
alter procedure proc_GetuserData(@username varchar(50))
as
begin
select * from tblPayment where username=@username 
end

exec proc_GetuserData 'hulk'

--------------------------get user payed by username and teststatus----
create proc proc_GetUpcomingTestResults(@username varchar(50), @teststatus varchar(50))
as
begin
select * from tblPayment where username = @username AND teststatus = @teststatus
end
delete from tblPayment where username='hulk'
----testcancel--
alter procedure proc_Updatestatus(@testid varchar(20),@cancelleddate varchar(20))
as
begin
update tblPayment set teststatus='Cancelled' , cancelleddate=@cancelleddate
where testid=@testid
end

exec proc_Updatestatus '28351'

----------update for expire---------

alter proc proc_UpdateExpire(@username varchar(50),@expire varchar(20))
 as
 begin 
 update tblPayment set teststatus='Expired' where testdate < @expire AND teststatus='Upcoming'
 end

 exec proc_UpdateExpire 'hulk', '2019-12-19'
 exec proc_UpdateExpire 'hulk'

 select * from tblPayment where testdate > GETDATE() OR testdate = GETDATE()
 --------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------------
-------------------------------------------------------SCORE TABLE MAIN ------------------------------
select * from tblScores

 create table tblScores (username varchar(50),testid varchar(20),testmodel varchar(50),score int)
 create proc proc_InsertIntoScoresAfterTest(@username varchar(50),@testid varchar(20),@testmodel varchar(50),@score int)
 as
 begin
 insert into tblScores values (@username,@testid ,@testmodel ,@score )
 end

 ------------------------------SECOND UPDATE AFTER TEST--
 select * from tblPayment
alter proc proc_UpdateTestStatus(@testid varchar(20),@result int)
 as
 begin
 update tblPayment set teststatus='Completed' , cancelleddate='Completed', result= @result where testid = @testid
 end
 
 exec proc_UpdateTestStatus '87',2
-------------CHANGE OF DATETIME-------------------------------------
------------'YYYY-MM-DD HH:MM:SS'-------------------
--------------------UPDATE products SET former_date='2011-12-18 13:17:17' WHERE id=1------------

create table student (id int, slote datetime, teststatus varchar(10))

insert into student values(1, '2014-12-12 23:40:55','Upcoming')

Update student
SET teststatus = 'Expired' 
WHERE datetime > CURRENT_TIMESTAMP + INTERVAL 1 MINUTE;
Update student
SET teststatus = 'Expired' 
WHERE CURRENT_TIMESTAMP >  CURRENT_TIMESTAMP +  '0000-00-00 00:2:00'

SELECT CURRENT_TIMESTAMP

SELECT SESSION_USER

SELECT SESSIONPROPERTY('ANSI_NULLS')


CREATE TABLE tablename1 (                                                       
   id bigint(20) NOT NULL ,                                        
   string varchar(50) not NULL,                                              
    PRIMARY KEY  (id)                                                             
    )

UPDATE student
 SET teststatus = NOW() - INTERVAL 1 DAY
 WHERE user = 'test_exp'

 CREATE EVENT 'session'  -- create your event
    ON SCHEDULE
      EVERY 24 HOURS  -- run every 24 hours
    DO
      UPDATE myschema.youtable set mycolumn='1'



	  create table #t
(
CreateDate datetime
)

select * from #t
Insert Into #t 
select GETDATE() union all
Select DateAdd(month,04, getdate())

Select Case When CreateDate < getdate() And 
       Getdate() < Cast(str(DatePart(year, getdate())) + '-03-31' as datetime) Then 
       'Active' Else 'Expired' end as  [Status],
       CreateDate From #t
	   CREATE TABLE t1 (
  ts TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  dt DATETIME DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE dbo.YourTable
(  
    FooId INT PRIMARY KEY CLUSTERED,   
    FooName VARCHAR(50) NOT NULL,
    modstamp datetime2 GENERATED ALWAYS AS ROW START NOT NULL,   
    MaxDateTime2 datetime2 GENERATED ALWAYS AS ROW END NOT NULL,     
    PERIOD FOR SYSTEM_TIME (modstamp,MaxDateTime2)    
)  

INSERT INTO dbo.YourTable (FooId, FooName)
VALUES      (1,'abc');

SELECT * FROM   dbo.YourTable;
---DECLARE @TimeToExecute DATETIME
---SET @TimeToExecute = '2019-12-13 10:18:07.370'


--WAITFOR TIME @TimeToExecute
WAITFOR DELAY '00:00:05'

UPDATE dbo.YourTable
SET    FooName = 'xyz'
WHERE  FooId = 1;

SELECT *
FROM   dbo.YourTable;

DELETE FROM YourTable






DROP TABLE dbo.YourTable; 
---------

alter trigger tr_somename 
On tablename
For update
As 
Begin
    Set nocount on; 
       Update t
        Set t.field_name = getdate()
        From table_name t inner join inserted I 
        On t.pk_column = I.pk_column
End

select * from student
----------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------ADMIN PROCEDURE   STARTS------------------------------------------------------------------
create database exam

create table tblCandidates(name varchar(100),
email varchar(100),
phone varchar(10),
username varchar (50) primary key,
password varchar (50))

insert into tblCandidates values('Priya','priya123@gmail.com','9876543210','PriyaSweety','priya123')
insert into tblCandidates values('Gayathri','gayu68@gmail.com','9879663210','GayuCherry','gayu06')
insert into tblCandidates values('Siva','siva456@gmail.com','9876524510','SivaRokzz','siva222')
insert into tblCandidates values('Sowmeya','sowmi@gmail.com','9046843210','SowmiKutti','sowmi39')

select * from tblCandidates

create table tblQuestions(SNo int constraint pk_Sn primary key,TestModel varchar(50),Questions varchar(1000),
Answers varchar(100),option1 varchar(100),option2 varchar(100),option3 varchar(100),option4 varchar(100),
Mark int)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(01,'Aptitude',
'A sum of money at simple interest amounts to Rs. 815 in 3 years and to Rs. 854 in 4 years','option3','Rs.650','Rs.690','Rs.698','Rs.700',1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(02,'Aptitude',
'A sum fetched a total simple interest of Rs. 4016.25 at the rate of 9 p.c.p.a. in 5 years. What is the sum?','option4',
'Rs.4462.50',
'Rs.8032.50',
'Rs.8900',
'Rs.8925',
1)

Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(3,'Technical',
'Which of these constructors is used to create an empty String object?','option1',
'String()',
'String(void)',
'String(0)',
'none',
1)


Insert into tblQuestions (SNo,TestModel,Questions,Answers,option1,option2,option3,option4,Mark) values(4,'Technical',
'What is the return type of Constructors?','option4',
'int',
'float',
'void',
'none of the mentioned above',
1)


select *from tblQuestions--------
------------------------------------------------------------------

create table TestModules(ModuleNo varchar(50)primary key, ModuleName varchar(50))
drop table TestModules
insert into TestModules values('2','Technical')
select  * from TestModules
-------------------------------------------------------------------------------
create proc proc_GetAllQuestionsforAdmin(@TestModel varchar(50))
as
begin
select * from tblQuestions where TestModel=@TestModel
end

exec proc_GetAllQuestionsforAdmin 'Aptitude'
-------------------------------------------------------------------------------------

create proc proc_GetTestTypeQuestions(@TestModel varchar(50))
as
begin
  select * from tblQuestions where TestModel=@TestModel
  end

  drop proc proc_GetTestTypeQuestions
---------------------------------------------------------------------------------
create proc proc_GetQuestions
as
begin
select * from tblQuestions
end

-----------------------------------------------------------------------
create proc proc_AddQuestion(@TestModel varchar(50),@Questions varchar(1000),@Answers varchar(100),@option1 varchar(100),@option2 varchar(100),@option3 varchar(100),@option4 varchar(100),@Mark int)
as
declare @No varchar(10),@null varchar(10),@SNo int,@SNo1 int
set @null = 0

begin	
select @No = (select count(*) from tblQuestions)
if @No = @null
begin
set @SNo = @No+1
insert into tblQuestions values(@SNo,@TestModel,@Questions,@Answers,@option1,@option2,@option3 ,@option4,@Mark)
end
else
begin
select @SNo1 = (select max(SNo) from tblQuestions)
set @SNo1 = @SNo1+1
    insert into tblQuestions values(@SNo1,@TestModel,@Questions,@Answers,@option1,@option2,@option3 ,@option4,@Mark)
end
end

drop proc proc_AddQuestion
------------------------------------------------------------------------
select * from tblQuestions
delete from tblQuestions
exec proc_AddQuestion 'Aptitude','add 2+2','4','1','4','3','5','1'
insert into tblQuestions values('1','Aptitude','add 2+2','4','1','4','3','5','1')

update tblQuestions set SNo=10 where SNo=215

create proc proc_GetTestType(@testtype varchar(50))
as begin
select SNo,Questions,Answers,option1,option2,option3,option4,Mark from tblQuestions where TestModel=@testtype
end

exec proc_GetTestType'Aptitude'
-----------------------------------------------------
create proc proc_UpdateQuestion(@TestModel varchar(50),@Question varchar(1000),@Answer varchar(100),@option1 varchar(100),
@option2 varchar(100),@option3 varchar(100),@option4 varchar(100),@Mark int,@SNo int)
as
begin
    update tblQuestions set TestModel=@TestModel,Questions=@Question,Answers=@Answer,option1=@option1,option2=@option2,
         option3=@option3,option4=@option4,Mark=@Mark where SNo=@SNo
end

exec proc_UpdateQuestion 'Aptitude','eeeeeeee','option1','qwerfds','erefdfd','ewewe','tryuii','1','10'
--------------------------------------------------------------
create proc proc_DeleteQuestion(@SNo int)
as 
declare @inc int
set @inc = 1
begin
delete from tblQuestions where SNo=@SNo
while(@inc <= 10000)
begin 
update tblQuestions set SNo = @inc where SNo=(select min(SNo) as T from tblQuestions where SNo > @inc )
set @inc = @inc + 1
end
end
exec proc_DeleteQuestion '1'
---------------------------------------------------------


create table tblRegisterDetails(name varchar(100),
email varchar(100),
phone varchar(10),
username varchar (50) primary key)

insert into tblRegisterDetails values('Priya','priya123@gmail.com','9876543210','PriyaSweety')
insert into tblRegisterDetails values('Gayathri','gayu68@gmail.com','9879663210','GayuCherry')
insert into tblRegisterDetails values('Siva','siva456@gmail.com','9876524510','SivaRokzz')
insert into tblRegisterDetails values('Sowmeya','sowmi@gmail.com','9046843210','SowmiKutti')

create proc proc_GetUserDetails
as
begin
  select *from tblCandidates
end

exec proc_GetUserDetails

-------------------------------------------------------------------------------
create table tblAdminDetails
(Admin_name varchar(100),Admin_email varchar(100),Admin_phone varchar(10),Admin_username varchar(50),Admin_password varchar(50),Admin_Image varchar(100))

ALTER TABLE tblAdminDetails
ADD 
drop table tblAdminDetails

insert into tblAdminDetails values('ShivaGanesh','siva11@gmail.com','9054843210','siva012','123','assets/images/shivaganesh pic.jpg')
insert into tblAdminDetails values('Ahamed','ahamed123@gmail.com','9876547810','ahamed123','123','assets/images/ahamed pic.jpg')
insert into tblAdminDetails values('Aravind','aravind68@gmail.com','9879664410','aravind456','456','assets/images/aravind pic.jpg')
insert into tblAdminDetails values('ShanmugaPriya','priya456@gmail.com','9876524890','priyasp789','123','assets/images/sp pic.jpg')
insert into tblAdminDetails values('Gayathri','gayu11@gmail.com','9054843210','gayu012','123','assets/images/My Pic.jpg')
insert into tblAdminDetails values('Sowmeya','sowmeya123@gmail.com','9876987810','sowmi123','123','assets/images/sowmeya pic.jpg')
insert into tblAdminDetails values('Anusha','anu68@gmail.com','9779664410','anusha456','123','assets/images/anusha pic.jpg')
insert into tblAdminDetails values('Priya','priya456@gmail.com','9876524890','priya789','123','assets/images/priya pic.jpg')

drop table tblAdminDetails
---------------------------------
create proc proc_AdminDetails
as
begin
 select *from tblAdminDetails
end
delete from tblAdminDetails where Admin_Image='assets/images/shivaganesh pic.jpg'


--admin login validation
create proc proc_AdminUserValidation(@p_Username varchar(50), @p_password varchar(50))
as
begin
select * from tblAdminDetails where Admin_username = @p_Username AND Admin_password = @p_password
end
--

exec proc_AdminDetails
----------------------------------------------------------------------------------------------------------------
create table tblPaidUsers(name varchar(100),
email varchar(100),
phone varchar(10),
TestModel varchar(50),date varchar(20))

insert into tblPaidUsers values('Priya','priya123@gmail.com','9876543210','Aptitude','26/12/2019')
insert into tblPaidUsers values('Gayathri','gayu68@gmail.com','9879663210','Technical','27/12/2019')
insert into tblPaidUsers values('Siva','siva456@gmail.com','9876524510','Aptitude','28/12/2019')
insert into tblPaidUsers values('Gayathri','gayu11@gmail.com','9054843210','Technical','29/12/2019')

create proc proc_GetPaidUsers
as
begin
  select  *from tblPayment
end

exec proc_GetPaidUsers
---------------------------------------------------------------------------------------------------------


create table tblScores(name varchar(50),email varchar(100),phone varchar(10),Testmodel varchar(50),score int)

insert into tblScores values('Priya','priya123@gmail.com','9876543210','Aptitude',8)
insert into tblScores values('Gayathri','gayu68@gmail.com','9879663210','Technical',7)
insert into tblScores values('Siva','siva456@gmail.com','9876524510','Aptitude',9)
insert into tblScores values('Gayathri','gayu11@gmail.com','9054843210','Technical',9)

create proc proc_GetScoreDetails
as
begin
select *from tblScores
end

exec proc_GetScoreDetails



----------------------------------------------ADMIN PROCEDURES END-----------------------------------------------------------

-------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------

create table tblScores(CandidateId varchar(20) primary key, Username varchar(50) 
foreign key references tblCandidates(Username),TestModel varchar(50),Mark int)

create proc proc_GetAllScores(@Username varchar(50),@CandidateId varchar(20) out,  @TestModel varchar(50) out,@Mark int out)
as
begin
select @CandidateId = CandidateId , @TestModel = TestModel, @Mark = Mark from tblScores where Username= @Username
end

select * from tblScores
truncate table tblScores

---------------------------------

--INSERT into SCORES--
create proc proc_InsertIntoScores(@CandidateId varchar(20),@Username varchar(50),  @TestModel varchar(50),@Mark int)
as
begin 
insert into tblScores values(@CandidateId,@Username,@TestModel,@Mark)
end
sp_help tblScores
----------------------------
--- GETTING TEST MODELS FROM QUESTIONS TABLE---
alter proc proc_GetAllTestModels 
as 
begin
select TestModel from tblQuestions group by TestModel
end

declare 
@TestModel varchar(50)
exec proc_GetAllTestModels 
select @TestModel



select * from tblScores

select CandidateId,TestModel,Mark from tblS
------------------------------------------------------------------------------------------
create proc proc_CheckPayment(@username varchar(50),@candidate_id varchar(20))
as
begin
select * from tblPayment where Username=@username AND CandidateId = @candidate_id
end

create proc proc_CheckUserInPaymentTable(@username varchar(50),@testmodel varchar(50))
as
begin
select * from tblPayment where Username=@username AND TestModel = @testmodel
end
-------------------------------------------------------------------------------------------------
create table tblTestScorestemp(sno int ,options varchar(100))

alter table tblTestScorestemp
drop column unique_id
alter proc proc_InsertTempScore(@sno int ,@options varchar(100))
as
begin
insert into tblTestScorestemp values (@sno,@options)
end
--------------------------------------------------------
alter proc procSelectCount
as
begin
select count(*) from tblTestScorestemp
end
exec procSelectCount
select * from tblTestScorestemp
 
 ------------------------------------------------------------------------------------------
 ----TRUNCATE TABLE TEMP SCORES----
create proc proc_TruncateScores
as
begin
truncate table tblTestScorestemp
end
---------------------------------------------------------------------------------------------
create proc proc_DeleteUser(@Username varchar(50),@testmodel varchar(50))
as
begin 
delete from tblPayment where  Username = @Username AND TestModel = @testmodel
end
select * from tblPayment
------
exec proc_DeleteUser 'Ahamed','Aptitude'

------------------------------

insert into tblPayment values('1256','hamed','Technical',1)
select * from tblPayment

alter proc proc_GetCandID(@username varchar(50),@testmodel varchar(50))
as begin
 select CandidateId from tblPayment where Username=@username AND TestModel=@testmodel
end

exec proc_GetCandID 'Ahamed','Technical'

create table tblTempScores(candidateid varchar(20),mark int)
-------------------------------------
create proc proc_UpdateTempScore(@candidateid varchar(20), @mark int)
as
begin
insert into tblTempScores values (@candidateid,@mark)
end
----------------------------
create proc proc_TruncateScoreCalculate
as
begin
truncate table tblTempScores
end
exec proc_TruncateScoreCalculate

select * from tblTempScores
----------------------------------------
alter proc proc_InsertTempScore(@sno int ,@options varchar(100))
as
begin
insert into tblTestScorestemp values (@sno,@options)
end




---------------------------------

alter proc proc_Calculate
as
begin 
select sum(mark) from tblTempScores group by candidateid
end

-----------

create proc proc_UpdateScores(@candidateid varchar(20), @mark int)
as
begin
update tblScores set Mark = Mark+@mark where CandidateId=@candidateid
end

select * from tblPayment
delete from tblPayment where Username = 'Ahamed'


Update tblQuestions set Answers='Option3'
where SNo=1

Update tblQuestions set Answers='Option4'
where SNo=2

Update tblQuestions set Answers='Option3'
where SNo=3

Update tblQuestions set Answers='Option4'
where SNo=4

Update tblQuestions set Answers='Option3'
where SNo=5

Update tblQuestions set Answers='Option4'
where SNo=6

Update tblQuestions set Answers='Option1'
where SNo=7

Update tblQuestions set Answers='Option2'
where SNo=8

Update tblQuestions set Answers='Option4'
where SNo=9

Update tblQuestions set Answers='Option3'
where SNo=10

Update tblQuestions set Answers='Option3'
where SNo=11

Update tblQuestions set Answers='Option1'
where SNo=12

Update tblQuestions set Answers='Option4'
where SNo=13

Update tblQuestions set Answers='Option2'
where SNo=14

Update tblQuestions set Answers='Option1'
where SNo=15

Update tblQuestions set Answers='Option4'
where SNo=16

Update tblQuestions set Answers='Option3'
where SNo=17

Update tblQuestions set Answers='Option1'
where SNo=18

Update tblQuestions set Answers='Option4'
where SNo=19

Update tblQuestions set Answers='Option2'
where SNo=20
-----------------

--check for user in viewprofile---
alter proc proc_CheckUserinScores(@username varchar(50))
as
begin
select * from tblScores where Username = @username
end



-----------------------------------
truncate table tblTestScorestemp
truncate table tblTempScores
----------------------------------------------