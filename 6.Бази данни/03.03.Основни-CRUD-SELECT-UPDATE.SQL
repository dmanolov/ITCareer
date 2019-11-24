use soft_uni;

-- Problem 2.	Намерете цялата информация за отделите
select * from departments;

-- Problem 3.	Намерете всички имена на отдели
select name from departments;

-- Problem 4.	Намерете заплатата на всеки служител
select first_name,last_name,salary from employees;

-- Problem 5.	Намерете пълното име на всеки служител
select first_name, middle_name, last_name from employees;

-- Problem 6.	Намерете имейл адреса на всеки служител
select concat(first_name, '.', last_name, '@softuni.bg') as full_email_address from employees;

-- Problem 7.	Намерете всички различни работни заплати
select DISTINCT salary from employees ORDER BY salary;

-- Problem 8.	Намерете цялата информация за служители
select * from employees WHERE job_title = 'Sales Representative';

-- Problem 9.	Намерете имената на всички служители със заплата в диапазон
select first_name, last_name, job_title from employees WHERE salary BETWEEN 20000 and 30000;

-- Problem 10.	 Намерете имената на всички служители
select concat(first_name, ' ', middle_name, ' ', last_name) as full_name 
 from employees WHERE salary 
  in (25000, 14000, 12500, 23600);

-- Problem 11.	 Намерете всички служители без мениджър
select first_name, last_name from employees WHERE manager_id is null;

-- Problem 12.	 Намерете всички служители със заплата повече от 50000
select first_name, last_name, salary from employees WHERE salary > 50000 ORDER BY salary desc;

-- Problem 13.	 Намете 5 най-добре платени служителя
select first_name, last_name from employees ORDER BY salary desc limit 5;

-- Problem 14.	Намерете всички служители, които не са от отдел Marketing 
select first_name, last_name from employees where department_id != 4;

-- Problem 15.	Различни длъжности
select DISTINCT job_title FROM employees ORDER BY job_title;

-- Problem 16.	Намерете първите 10 започнати проекти
select*from projects order by start_date, name limit 10;

-- Problem 17.	 Последните 7 наети служители
select first_name, last_name, hire_date from employees ORDER BY hire_date desc;

-- Problem 18.	Увеличаване на заплати
update employees set salary = salary*1.12 where department_id in (1,2,4,11);
select salary from employees;

use geography;

-- Problem 19.	 Всички планински върхове
select peak_name from peaks ORDER BY peak_name;

-- Problem 20.	 Най-големи по население страни
select country_name, population from countries 
 where continent_code = 'EU' 
  ORDER BY population DESC limit 30;
  
-- Problem 21.	 Страни и валута  (Euro / Not Euro)
select country_name, country_code, 
 (case when currency_code = 'EUR' then 'Euro' else 'Not Euro' end) 
  as currency from countries 
   order by country_name;
   
use diablo;

-- Problem 22.	Всички символи Diablo
select name from characters ORDER BY name;