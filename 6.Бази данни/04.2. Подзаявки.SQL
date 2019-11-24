use soft_uni;

-- Problem 1.	Най-ниско платени служители
select first_name, last_name, salary from employees 
 where salary = (select  salary from employees ORDER BY salary limit 1);
 
 -- Problem 2.	Служители с близки до най-ниските заплати
 select first_name, last_name, salary from employees 
  where salary < 1.10 * (select  salary from employees ORDER BY salary limit 1)
   order by salary;
   
-- Problem 3.	Всички мениджъри
select first_name, last_name, job_title from employees 
 where employee_id = any (select distinct manager_id from employees) 
  order by first_name, last_name;
  
-- Problem 4.	Служителите от San Francisco
select first_name, last_name from employees 
 where address_id = any (select address_id from addresses 
  where town_id = (select town_id from towns where name = 'San Francisco'))
   order by first_name;