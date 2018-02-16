use Detail;
create table cutomer(cid int,cname varchar(20),age int,salary int);
sp_help customer;
exec sp_rename 'cutomer' , 'customer';
insert into customer (cid,cname,age,salary)values(2,'ritu',23,3226),( 3 ,'jyoti',28,2054),(4,'renu',32,1200);
create table orderTable(orderid int,date date,cid int,amount int);
insert into orderTable(orderid,date,cid,amount)values(201,'2018-2-2',3,4220),(302 ,'2018-3-23',2,5000),(403,'2018-7-2',1,3200);
select * from customer;
select cid ,amount ,date,cname from customer inner join orderTable on customer.cid=ordertable.ordercusid; 
select cid ,amount ,date,cname from customer left join orderTable on customer.cid=ordertable.ordercusid; 
select cid ,amount ,date,cname from customer right join orderTable on customer.cid=ordertable.ordercusid; 
select cid ,amount ,date,cname from customer full join orderTable on customer.cid=ordertable.ordercusid; 
SELECT  a.cid, b.cname, a.salary FROM customer a, customer b WHERE a.salary < b.salary;

