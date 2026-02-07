create database test3;
use test3;


create table Department(
DepartmentId int primary key,
DepartmentName varchar(100)
);


create table Employee(
EmpId int primary key,
EmpName varchar(80) unique,
Email varchar(80),
DepartmentId int not null,
foreign key (DepartmentId) references Department (DepartmentId)
);

create table Sales(
SaleId int primary key,
EmpId int not null,
SaleMonth varchar(40),
SaleYear int,
SaleAmount int,
foreign key (EmpId) references Employee (EmpId)
);


insert into Department (DepartmentId, DepartmentName)
values
(1, 'IT'),
(2, 'HR'),
(3, 'Sales');


insert into Employee (EmpId, EmpName, Email, DepartmentId, BonusPoints)
values
(101, 'Marimuthu', 'mari@gmail.com', 1, 0),
(102, 'Ravi', 'ravi@gmail.com', 2, 0),
(103, 'Anita', 'anita@gmail.com', 3, 0);


insert into Sales (SaleId, EmpId, SaleMonth, SaleYear, SaleAmount)
values
(1, 101, 'January', YEAR(GETDATE()), 60000),
(2, 101, 'February', YEAR(GETDATE()), 25000),
(3, 102, 'March', YEAR(GETDATE()), 8000),
(4, 103, 'April', YEAR(GETDATE()), 45000);


alter table Employee
add BonusPoints int default 0;

select * from Employee;

alter table Employee
add constraint c
check (BonusPoints between 0 and 100);


select e.EmpName,
d.DepartmentName,
s.SaleMonth,
s.SaleYear,
s.SaleAmount
from Sales s
join Employee e on s.EmpId = e.EmpId
join Department d on e.DepartmentID = d.DepartmentId;



select e.EmpName,
sum(s.SaleAmount) as TotalSales
from employee e
join Sales s on e.EmpId = s.EmpId
where s.SaleYear = Year(GETDATE())
group by e.EmpName;


select EmpName,
left (EmpName,3)
+ left (DepartmentName,2)
+cast(EmpId as varchar) as MadeName
from Employee
join Department 
on Employee.DepartmentId = Department.DepartmentId; 


select EmpName 
from Employee
where EmpId in(
select EmpId from [Sales] 
group by EmpId
having sum(SaleAmount)>
(
select avg(Totalsale)
from (select sum(SaleAmount) as Totalsale from Sales
group by EmpID
) T
)
);



select e.EmpName,
s.SaleAmount,
'High' as Category
from sales s
inner join Employee e on s.EmpId = e.EmpID
where s.SaleAmount > 50000

union

select e.EmpName,
s.SaleAmount,
'Low' as Category
from sales s
inner join Employee e on s.EmpId = e.EmpID
where s.SaleAmount < 10000;



create trigger bonustrigger
on sales 
after insert
as
begin
	update e 
	set BonusPoints = 
	case
		when i.SaleAmount >= 50000 then 10
		when i.SaleAmount >= 20000 then 5
		else 0
		end
		from employee e
		inner join inserted i on e.EmpId = i.EmpID
end

select * from Employee;
insert into [Sales] (SaleId, EmpId, SaleMonth, SaleYear, SaleAmount)
values (10, 101, 'May', YEAR(GETDATE()), 60000);



select e.EmpName,
d.DepartmentName,
sum(s.SaleAmount) as TotalSale,
e.BonusPoints,
case
	when e.bonuspoints >= 50 then 'A'
	when  e.bonuspoints between 20 and 49 then 'B'
	else 'C'
	end as PerformanceGrade
	from Employee e
	join Department d on e.DepartmentId = d.DepartmentId
	join [sales] s on e.EmpId = s.EmpId
	group by e.EmpName,  d.DepartmentName , e.bonuspoints;








