insert into Client (ClientID, CFName, CLName, Age, Phone, [Address(...)], ZipCode, CriminalRecord, Military)
values (1, 'Shelby', 'Savely', 18, 405-623-4139, '600 Oak Street', 45784, 'No', 'No');

select *
from Client

insert into Client (ClientID, CFName, CLName, Age, Phone, [Address(...)], ZipCode, CriminalRecord, Military)
values (2, 'Grace', 'Cody', 62, 405-621-2740, '600 Landers Street', 71113, 'Yes', 'No'),
(3, 'James','French',37, 713-093-4928,'645 Blanchard Ave', 67354,'No','Yes'),
(4, 'Charles','Darwin',90,918-240-0983,'2300 Evolution Circle',37590,'Yes','Yes'),
(5, 'Lewis','Goodwin',32,800-409-1738,'900 Elmers Street',46981,'No','Yes'),
(6, 'Francesca','Varpen', 26, 402-719-0128,'190 Chester Drive',19462, 'No','No'),
(7, 'Gabe','Smith', 45, 703-480-7645,'3641 24 Ave NE', 75648,'Yes','No'),
(8, 'Anhthu','Tran',27, 918-402-7800,'300 Barker Street',90128,'No','No'),
(9, 'Charlie','Nguyen',25,405-980-1273,'4590 Asp Lane',80928,'No','Yes'),
(10,'Patrick','Williams',21,713-900-8972,'1400 May Avenue',73120,'No','No');

insert into Employee (EmpID, EFName, ELName, Salary, Position)
values (201,'Charles','Bernard',190000,'Attorney'),
(202, 'Megan','Cook',200000,'Attorney'),
(203,'William','Anderson',200000,'Attorney'),
(204, 'Enrique','West',50000,'Admin'),
(205,'Damien','Braun',55000,'Admin'),
(206,'Ellie','Osborne',52000,'Admin'),
(207,'Cierra','Vega',80000,'Paralegal'),
(208, 'Aiden','Cantrell',80000,'Paralegal'),
(209, 'Kierra','Gentry',75000,'Paralegal'),
(210, 'Pierra','Cox',82000,'Paralegal'),
(211, 'Thomas','Crane',80000,'Paralegal'),
(212,'Sara','Gray',79000,'Paralegal'),
(213, 'Giana','Diaz',86000,'Paralegal'),
(214, 'Jordan','Fuentes',81000,'Paralegal'),
(215,'Paola','Spence',80000,'Paralegal'),
(216,'Dillon','Pruitt',82000,'Paralegal'),
(217,'Karla','Noble',25000,'Intern'),
(218,'Jon','Peters',25000,'Intern');

select *
from employee
insert into Service_Order (SOID,  ClientID, DatePlaced, DateCaseOpened, DateCaseClosed,Override,Decline,Description)
values (10,1,7-10-2019,10-24-2019,2-13-2021,'No','No','   '),
(11,2, 2-4-2019,3-10-2019,8-17-2019,'No','No','   '),
(12,3, 8-14-2018,11-21-2018,5-15-2020,'Yes','No','    '),
(13,4, 2-15-2020, 2-16-2020,2-27-2021,'Yes','No','   '),
(14,5, 4-12-2015,7-20-2015,8-13-2017,'Yes','No','   '),
(15,6, 8-16-2014, 9-1-2014, 6-30-2015,'No','No','   '),
(16,7, 6-24-2010,7-19-2010,6-29-2011,'No','No','   '),
(17,8, 1-18-2005,2-10-2005,12-15-2006,'No','No','   '),
(18,9, 3-20-2018,6-4-2018,7-9-2020,'Yes','No','   '),
(19,10, 5-25-2017,6-5-2017,1-2-2018,'No','No', '   ');

insert into Payment (PaymentID, clientid, soid, Date)
values (101,1,10,4-12-2021),
(102,2, 11, 9-10-2019),
(103,3,12, 7-18-2020),
(104,4, 13, 3-29-2021),
(105, 5, 14, 10-12-2017 ),
(106,6, 15, 7-2-2015),
(107, 7, 16, 7-10-2011),
(108, 8, 17, 1-12-2006),
(109, 9, 18, 8-17-2020),
(110, 10, 19, 5-27-2018 );

select *
from Service_Order

select *
from Payment

insert into Service (servid, servname, price, discount)
values (301, 'divorce', 10000, null),
(302, 'car wreck',4000, null),
(303, 'sue', 5000,null),
(304,'writing a will',5000,null),
(305,'creating a contract', 3000, null),
(306,'leaving a contract',4000,null),
(307, 'opening a business', 10000, null),
(308, 'custody', 15000,null),
(309, 'legal advice', 2000, null),
(310, 'other', 1000, null);

select *
from service

insert into Service_History(shid, soid, startdate, enddate, modifyinguser)
values (401,10, 10-25-2019,10-26-2019, 201),
(402, 11, 3-11-19,3-12-19,202),
(403, 12, 11-22-2018,11-23-2018,203),
(404, 13, 2-17-2020,2-18-2020,204 ),
(405, 14, 7-21-2015,7-22-2015,205),
(406, 15, 9-2-2014, 9-3-2014, 206),
(407, 16, 7-11-2010,7-12-2010, 207),
(408, 17, 2-11-2005, 2-12-2005, 208),
(409, 18, 6-5-2018, 6-6-2018, 209),
(410, 19, 6-5-2017, 6-6-2017, 210);

insert into Sales_Order_History(histid, soid, empid)
values (501, 10, 201),
(502, 11, 202),
(503, 12, 203),
(504, 13, 204),
(505, 14, 205),
(506, 15, 206),
(507, 16, 207),
(508, 17, 208),
(509, 18, 209),
(510, 19, 210);


insert into Sales_Order_Line(empid, soid, servid, hours)
values (201, 10, 301, 30),
(202, 11, 302, 40),
(203, 12, 303,  50),
(204, 13, 304, 37),
(205, 14, 305, 16),
(206, 15, 306, 24),
(207, 16, 307, 58),
(208, 17, 308, 29),
(209, 18, 309, 63),
(210, 19, 310, 25);







