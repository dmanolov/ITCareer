use soft_uni;

-- Problem 1.	Най-висока заплата по длъжности
select distinct job_title, salary from employees e 
 where salary = (select salary from employees 
  where job_title = e.job_title order by salary desc limit 1)
   order by salary desc, job_title;
   
-- Problem 2.	Най-ниско платени служители по отделиALTER
select first_name, last_name, salary, 
 (select name from departments where department_id = e.department_id) as 'department' 
  from employees e where salary = (select salary from employees 
   where department_id = e.department_id order by salary limit 1) 
	order by salary, first_name, last_name;
   
-- Problem 3.	Мениджъри с същото презиме 
select first_name, last_name from employees e
 where employee_id = any (select distinct manager_id from employees
  where middle_name = e.middle_name)
   order by first_name;
   
-- Problem 4.	Мениджъри с по-ниска заплата
select first_name, last_name from employees e
 where employee_id = any (select distinct manager_id from employees 
  where salary > e.salary)
   order by salary desc;
  
-- Problem 5.	Мениджъри с точно 5 подчинени
select first_name, last_name from employees e
 where exists  (select manager_id from employees 
  where manager_id = e.employee_id limit 4,1)
   and not exists (select manager_id from employees 
    where manager_id = e.employee_id limit 5,1)
    order by first_name;
    
-- Problem 6.	Планините в България
use geography;

select mountain_range, 
 (select peak_name from peaks where mountain_id = m.id order by elevation limit 1) as peak_name,
  (select elevation from peaks where mountain_id = m.id order by elevation limit 1) as elevation  
   from mountains m
    where id = any (select mountain_id from mountains_countries where country_code = 'BG') 
     order by elevation desc;
     
-- Problem 7.	Неописаните планини в България 
select mountain_range from mountains m
 where id = any (select mountain_id from mountains_countries where country_code = 'BG')
  and not exists (select * from peaks where mountain_id = m.id)
   order by mountain_range;