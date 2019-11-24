use soft_uni;

-- Problem 1.	Служители и техните мениджъри
(select first_name, last_name, ('(no manager)') as manager_name 
 from employees 
 where manager_id is null)

union

(select first_name, last_name, 
   (select concat(first_name, " ", last_name)
    from employees
    where employee_id = e.manager_id) as manager_name
 from employees e 
 where manager_id is not null 
 order by manager_name);
 
-- Problem 2.	Тримата най-добре платени
(select first_name, last_name, 'manager' as position, salary from employees 
where employee_id = any (select distinct manager_id from employees where manager_id is not null)
order by salary desc limit 3)

union

(select first_name, last_name, 'employee' as position, salary from employees
where employee_id not in (select distinct manager_id from employees where manager_id is not null)
order by salary desc limit 3);

-- Problem 3.	Планините в България
use geography;

(select mountain_range, 
  ( select peak_name from peaks where mountain_id = m.id order by elevation desc limit 1) as peak,
  ( select elevation from peaks where mountain_id = m.id order by elevation desc limit 1) as elevation
 from mountains m
 where id = any(select mountain_id from mountains_countries where country_code = 'BG')
    and id = any (select distinct mountain_id from peaks))

union

(select mountain_range, 
  'no' as peak,
  'info' as elevation
 from mountains m
 where id = any(select mountain_id from mountains_countries where country_code = 'BG')
    and id not in (select distinct mountain_id from peaks));

