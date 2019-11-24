use soft_uni;

-- Problem 1.	Адрес на служител
select e.employee_id, e.job_title, a.address_id, a.address_text 
 from employees e
    join addresses a 
     on e.address_id = a.address_id
 order by a.address_id 
 limit 5;
 
-- Problem 2.	Служител по продажбите
select e.employee_id, e.first_name, e.last_name, d.name as department_name
 from employees e
   join departments d 
    on d.department_id = e.department_id
 where d.name = 'Sales'
 order by e.employee_id desc;

-- Problem 3.	Служебни отдели
select e.employee_id, e.first_name, e.salary, d.name as department_name
 from employees e
   join departments d
    on d.department_id = e.department_id
where e.salary > 15000
order by d.department_id desc
limit 5;

-- Problem 4.	Служители без проект
select e.employee_id, e.first_name
 from employees e
   left join employees_projects ep
    on e.employee_id = ep.employee_id
where ep.project_id is null
order by e.employee_id desc
limit 3;

-- Problem 5.	Мениджър на служителите
select e.employee_id, e.first_name, e.manager_id, m.first_name as manager_name
 from employees e
	join employees m
     on e.manager_id = m.employee_id and e.manager_id in (3,7)
order by e.first_name;

-- Problem 6.	Минимална заплата
select e.salary, d.name 
 from employees e
	join departments d
     on d.department_id = e.department_id
 order by e.salary limit 1;
 
-- Problem 7.	Държави без планини
use geography;

select c.country_name 
 from countries c
	left join mountains_countries m
     on m.country_code = c.country_code
 where m.mountain_id is null
 order by c.country_name;