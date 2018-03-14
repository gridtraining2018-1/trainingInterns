sp_help customerTable;
exec sp_databases;
use master;
select * from CustomerTable;
update CustomerTable set customerId=6 where customerAdress is null ;
select * from CustomerTable order by customerId;
alter table customerTable add  salary int; 
delete from CustomerTable where salary =321 or salary = 23 or salary = 123;
sp_help CustomerTable;
update CustomerTable  SET salary = (case when customerId = 1 then '6220'
                         when customerId = 2 then '2919'
                         when customerId = 3 then '0230'
                         when customerId = 4 then '6230'
                         when customerId = 5 then '6130'
                         when customerId = 6 then '6120'
                    end);
ALTER TABLE customerTable ADD PRIMARY KEY (customerId);
insert into CustomerTable (customerId,customerName) values (1,'rakesh'); 
SELECT COUNT(CustomerID), salary
FROM CustomerTable
GROUP BY salary;

