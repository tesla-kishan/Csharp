CREATE database Prod_22;
use Prod_22;




create table products(
Product_Id int Primary Key,
Product_Name varchar(50)
);


create table Sales(
Sale_Id int Primary Key,
Product_Id int,
Foreign Key (Product_Id) References products(Product_Id)
);

INSERT INTO Products VALUES
(1,'Laptop'),
(2,'Mouse'),
(3,'Keyboard'),
(4,'Monitor');

INSERT INTO Sales VALUES
(101,1),
(102,3);


select p.Product_Id ,p.Product_Name
from products p 
left join sales s 
on p.Product_Id = s.Product_Id
where s.product_id is null;